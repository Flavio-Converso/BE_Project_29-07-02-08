using BE_Project_29_07_02_08.Context;
using BE_Project_29_07_02_08.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Project_29_07_02_08.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _dataContext;
        public AuthService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User> RegisterAsync(User user)
        {
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }


        public async Task<User> LoginAsync(User user)
        {
            await _dataContext.Users
                 .Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefaultAsync();
            return user;
        }


    }
}
