using QuickKartApi.Models;

namespace QuickKartApi.Repository
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync( string username);
        Task CreateAsync(User user);
    }
}
