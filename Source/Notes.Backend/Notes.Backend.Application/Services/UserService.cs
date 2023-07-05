using Notes.Backend.Domain.Models;

namespace Notes.Backend.Application.Services
{
    public class UserService
    {
        private User _user;
        
        public UserService(User user)
        {
            _user = user;
        }

        /*public async Task<User> RegisterUser(string login, string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }*/
    }
}
