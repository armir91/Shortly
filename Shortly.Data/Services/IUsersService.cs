using Shortly.Data.Models;

namespace Shortly.Data.Services
{
    public interface IUsersService
    {
        Task<List<AppUser>> GetUsersAsync();
/*        Task<AppUser> AddAsync(AppUser user);
        Task<AppUser> GetByIdAsync(string id);
        Task<AppUser> UpdateAsync(string id, AppUser user);
        Task DeleteAsync(string id);*/
    }
}
