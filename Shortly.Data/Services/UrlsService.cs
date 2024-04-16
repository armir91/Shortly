using Microsoft.EntityFrameworkCore;
using Shortly.Data.Models;

namespace Shortly.Data.Services
{
    public class UrlsService : IUrlsService
    {
        private readonly AppDbContext _context;

        public UrlsService(AppDbContext context)
        {
            _context = context;
        }

        public Url GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Url> GetUrls()
        {
            var allUrls = _context
                .Urls
                .Include(user => user.User)
                .ToList();

            return allUrls;
        }

        public Url Add(Url url)
        {
            throw new NotImplementedException();
        }

        public Url Update(int id, Url url)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
