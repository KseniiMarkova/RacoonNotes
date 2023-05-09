namespace RacoonNotes.Abstractions.Services
{
    using RacoonNotes.Abstractions.Models.AuthService;
    using System;
    using System.Threading.Tasks;

    public interface IAuthDataService
    {
        public Task<User> GetUserAsync(string id);
        public Task<string> AddUserAsync(User user);
        Task<bool> IsUserExistByEmailAsync(string email);
        Task<bool> IsUserExistByUsernameAsync(string username);
    }
}
