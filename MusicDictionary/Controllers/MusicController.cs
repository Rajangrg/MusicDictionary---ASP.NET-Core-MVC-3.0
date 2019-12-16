using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //default landing page for music
        public IActionResult Index()
        {
            var result = _musicDb.Music.ToList();
            return View(result);
        }

        //GET  
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Music artist)
        {
            if (ModelState.IsValid)
            {
                _musicDb.Add(artist);
                await _musicDb.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        //GET - Edit 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editArtist = await _musicDb.Music.SingleOrDefaultAsync(m => m.Id == id);

            if(editArtist == null)
            {
                return NotFound();
            }

            return View(editArtist);
        }

        //Edit [POST]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Edit(Music artist)
        {
            if (ModelState.IsValid)
            {
                _musicDb.Update(artist);
                await _musicDb.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}