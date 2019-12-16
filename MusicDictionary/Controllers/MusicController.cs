using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicDictionary.Data;
using MusicDictionary.Models;

namespace MusicDictionary.Controllers
{
    public class MusicController : Controller
    {
        private readonly ApplicationDbContext _musicDb;
        //dependency injection 
        public MusicController(ApplicationDbContext musicDb)
        {
            _musicDb = musicDb;
        }
        //default landing page
        public IActionResult Index()
        {
            var result = _musicDb.Music.ToList();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Music music)
        {
            if (ModelState.IsValid)
            {
                _musicDb.Add(music);
                await _musicDb.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(music);
        }

    }
}