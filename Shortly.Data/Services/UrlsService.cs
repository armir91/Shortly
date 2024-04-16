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

        public async Task<Url> GetByIdAsync(int id)
        {
            var url = await _context.Urls.FirstOrDefaultAsync(x => x.Id == id);

            return url;
        }

        public async Task<List<Url>> GetUrlsAsync()
        {
            var allUrls = await _context
                .Urls
                .Include(user => user.User)
                .ToListAsync();

            return allUrls;
        }

        public async Task<Url> AddAsync(Url url)
        {
            await _context.Urls.AddAsync(url);
            await _context.SaveChangesAsync();

            return url;
        }

        public async Task<Url> UpdateAsync(int id, Url url)
        {
            var urlDb = await _context.Urls.FirstOrDefaultAsync(x => x.Id == id);
            if (urlDb != null)
            {
                urlDb.OriginalLink = url.OriginalLink;
                urlDb.ShortLink = url.ShortLink;
                urlDb.DateUpdated = url.DateUpdated;

                _context.Update(urlDb);
                await _context.SaveChangesAsync();
            }

            return urlDb;
        }

        public async Task DeleteAsync(int id)
        {
            var urlDb = await _context.Urls.FirstOrDefaultAsync(x => x.Id == id);
            if (urlDb != null)
            {
                _context.Urls.Remove(urlDb);
                await _context.SaveChangesAsync();
            }
        }
    }
}
