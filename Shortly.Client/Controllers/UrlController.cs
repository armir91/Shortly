﻿using Microsoft.AspNetCore.Mvc;
using Shortly.Client.Data.ViewModels;

namespace Shortly.Client.Controllers
{
    public class UrlController : Controller
    {
        public IActionResult Index()
        {
            //Fake DB data
            var allUrls = new List<GetUrlVM>()
            {
                new GetUrlVM()
                {
                    Id = 1,
                    OriginalLink = "https://link1.com",
                    ShortLink = "sh1",
                    NrOfClicks = 1,
                    UserId = 1
                },
                new GetUrlVM()
                {
                    Id = 2,
                    OriginalLink = "https://link2.com",
                    ShortLink = "sh2",
                    NrOfClicks = 2,
                    UserId = 2
                }
            };

            return View(allUrls);
        }

        public IActionResult Create()
        {
            return RedirectToAction("Index");
        }
    }
}