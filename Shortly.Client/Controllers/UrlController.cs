using Microsoft.AspNetCore.Mvc;
using Shortly.Client.Data.Models;

namespace Shortly.Client.Controllers
{
    public class UrlController : Controller
    {
        public IActionResult Index()
        {
            //DATA IS FROM DB
            /*var urlDb = new Url()
            {
                Id = 1,
                OriginalLink = "https://original.com",
                ShortLink = "shortly",
                NrOfClicks = 1,
                UserId = 1,
            };

            var allData = new List<Url>();
            allData.Add(urlDb);*/

            /*ViewData["ShortenedUrl"] = "Short Url";
            ViewData["AllUrls"] = new List<string>() { "Url 1", "Url 2", "Url 3"};*/

            /* ViewBag.ShortenedUrl = "Short Url";
             ViewBag.AllUrls = new List<string>() { "Url 1", "Url 2", "Url 3" };*/

            var tempData = TempData["SuccessMessage"];
            var viewbag = ViewBag.Test1;
            var viewData = ViewData["Test2"];

            if(TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }

            return View();
        }

        public IActionResult Create()
        {
            // Shorten URL
            var shortenedURL = "short";

            TempData["SuccessMessage"] = "Successful!";
            ViewBag.Test1 = "Test1";
            ViewData["Test2"] = "Test2";

            return RedirectToAction("Index");
        }
    }
}
