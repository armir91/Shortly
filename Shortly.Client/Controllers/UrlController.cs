using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shortly.Client.Data.ViewModels;
using Shortly.Data;
using Shortly.Data.Models;
using Shortly.Data.Services;

namespace Shortly.Client.Controllers
{
    public class UrlController : Controller
    {
        private readonly IUrlsService _urlsService;
        private readonly IMapper _mapper;

        public UrlController(IUrlsService urlsService, IMapper mapper)
        {
            _urlsService = urlsService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            var urls = _urlsService.GetUrls();

            /*.Select(url => new GetUrlVM()
                {
                    Id = url.Id,
                    OriginalLink = url.OriginalLink,
                    ShortLink = url.ShortLink,
                    NrOfClicks = url.NrOfClicks,
                    UserId = url.UserId,

                    User = url.User != null ? new GetUserVM()
                    {
                        Id = url.User.Id,
                        FullName = url.User.FullName
                    } : null
                })
                .ToList();*/

            var mappedAllUrls = _mapper.Map<List<GetUrlVM>>(urls);

            return View(mappedAllUrls);
        }

        public IActionResult Create()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id) 
        {
            _urlsService.Delete(id);

                /*.Urls
                .FirstOrDefault(url => url.Id == id);*/
                /*_urlsService.Urls.Remove(url);*/
                /*_urlsService.SaveChanges();*/

            return RedirectToAction("Index");
        }
    }
}
