using MongoDB.Driver;
using QuickKartApi.Models;

namespace QuickKartApi.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly IMongoCollection<User> _user;
        public UserRepository(IMongoDatabase database)
        {
            _user = database.GetCollection<User>("User");

        }

        public async Task<User> GetByUsernameAsync(string username)=>
            await _user.Find(u=>u.UserName == username).FirstOrDefaultAsync();

        public async Task CreateAsync(User user)=>
            await _user.InsertOneAsync(user);
        
           
    }
}
