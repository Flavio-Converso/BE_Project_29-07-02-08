using BE_Project_29_07_02_08.Context;
using BE_Project_29_07_02_08.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace BE_Project_29_07_02_08.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _dataContext;
        public AuthService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //todo: move this to a helper class
        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
        public async Task<User> RegisterAsync(User user)
        {
            user.Password = HashPassword(user.Password);
            var userRole = await _dataContext.Roles.Where(r => r.IdRole == 2).FirstOrDefaultAsync();
            user.Roles.Add(userRole);
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }


        public async Task<User> LoginAsync(User user)
        {
            string hashedPassword = HashPassword(user.Password);

            var existingUser = await _dataContext.Users
                 .Include(u => u.Roles)
                 .Where(u => u.Username == user.Username && u.Password == hashedPassword || u.Password == user.Password) //todo: remove u.Password == user.Password 
                 .FirstOrDefaultAsync();

            if (existingUser == null)
            {
                throw new Exception("Invalid username or password.");
            }
            return existingUser;
        }


    }
}
