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
            var url = _context.Urls.FirstOrDefault(x => x.Id == id);

            return url;
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
            _context.Urls.Add(url);
            _context.SaveChanges();

            return url;
        }

        public Url Update(int id, Url url)
        {
            var urlDb = _context.Urls.FirstOrDefault(x => x.Id == id);
            if (urlDb != null)
            {
                urlDb.OriginalLink = url.OriginalLink;
                urlDb.ShortLink = url.ShortLink;
                urlDb.DateUpdated = url.DateUpdated;

                _context.Update(urlDb);
                _context.SaveChanges();
            }

            return urlDb;
        }

        public void Delete(int id)
        {
            var urlDb = _context.Urls.FirstOrDefault(x => x.Id == id);
            if (urlDb != null)
            {
                _context.Urls.Remove(urlDb);
                _context.SaveChanges();
            }
        }
    }
}
