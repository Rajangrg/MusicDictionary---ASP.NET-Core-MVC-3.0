using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicDictionary.Data;

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


    }
}