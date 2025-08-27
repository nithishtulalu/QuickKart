using QuickKartApi.DTO_s;
using QuickKartApi.Helpers;
using QuickKartApi.Models;
using QuickKartApi.Repository;

namespace QuickKartApi.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public UserService(IUserRepository repo, IConfiguration config)
        {
            _config = config;
            _userRepository = repo;
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            try
            {
                var existing = await _userRepository.GetByUsernameAsync(dto.Username);
                if (existing != null) throw new Exception("Username already exists");
                var user = new User
                {
                    UserName = dto.Username,
                    PasswordHash = PasswordHasher.HashPassword(dto.Password),
                    Role = dto.Role,
                    Address = dto.Address,
                    Phone = dto.Phone
                };

                await _userRepository.CreateAsync(user);
                return JwtHelper.GenerateToken(user, _config);
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            try
            {
                var user = await _userRepository.GetByUsernameAsync(dto.Username);
                if (user != null && !PasswordHasher.VerifyPassword(dto.Password, user.PasswordHash))
                    throw new Exception("Invalid credentials");

                return JwtHelper.GenerateToken(user, _config);

            }
            catch (Exception ex)
            {
                return null ;
            }

        }
    }
}