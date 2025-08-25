using QuickKartApi.DTO_s;

namespace QuickKartApi.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}
