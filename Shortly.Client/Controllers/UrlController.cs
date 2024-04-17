using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shortly.Client.Data.Helpers.Roles;
using Shortly.Client.Data.ViewModels;
using Shortly.Data;
using Shortly.Data.Models;
using Shortly.Data.Services;
using System.Security.Claims;

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

        public async Task<IActionResult> Index()
        {
            var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole(Role.Admin);

            var urls = await _urlsService.GetUrlsAsync(loggedInUserId, isAdmin);

            var mappedAllUrls = _mapper.Map<List<GetUrlVM>>(urls);

            return View(mappedAllUrls);
        }

        public async Task<IActionResult> CreateAsync()
        {
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveAsync(int id) 
        {
            await _urlsService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
