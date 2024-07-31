using BE_Project_29_07_02_08.Models;

namespace BE_Project_29_07_02_08.Services.Auth
{
    public interface IAuthService
    {
        public Task<User> RegisterAsync(User user);
        public Task<User> LoginAsync(User user);

    }
}
