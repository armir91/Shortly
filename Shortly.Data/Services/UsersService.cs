using Microsoft.EntityFrameworkCore;
using Shortly.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortly.Data.Services
{
    public class UsersService : IUsersService
    {
        private readonly AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            _context = context;
        }

     /*   public async Task<AppUser> GetByIdAsync(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }*/

        public async Task<List<AppUser>> GetUsersAsync()
        {
            var allUSers = await _context
                .Users
                .Include(url => url.Urls)
                .ToListAsync();

            return allUSers;
        }

/*        public async Task<AppUser> AddAsync(AppUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<AppUser> UpdateAsync(string id, AppUser user)
        {
            var userDb = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userDb != null)
            {
                userDb.Email = user.Email;
                userDb.FullName = user.FullName;

                _context.Update(userDb);
                await _context.SaveChangesAsync();
            }

            return userDb;
        }

        public async Task DeleteAsync(string id)
        {
            var userDb = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userDb != null)
            {
                _context.Users.Remove(userDb);
                await _context.SaveChangesAsync();
            }
        }*/
    }
}
