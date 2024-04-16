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

        public User GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            return user;
        }

        public List<User> GetUsers()
        {
            var allUSers = _context
                .Users
                .Include(url => url.Urls)
                .ToList();

            return allUSers;
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User Update(int id, User user)
        {
            var userDb = _context.Users.FirstOrDefault(x => x.Id == id);
            if (userDb != null)
            {
                userDb.Email = user.Email;
                userDb.FullName = user.FullName;

                _context.Update(userDb);
                _context.SaveChanges();
            }

            return userDb;
        }

        public void Delete(int id)
        {
            var userDb = _context.Users.FirstOrDefault(x => x.Id == id);
            if (userDb != null)
            {
                _context.Users.Remove(userDb);
                _context.SaveChanges();
            }
        }
    }
}
