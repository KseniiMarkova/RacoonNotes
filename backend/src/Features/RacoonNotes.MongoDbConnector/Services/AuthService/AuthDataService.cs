namespace RacoonNotes.MongoDbConnector.Services.AuthService
{
    using RacoonNotes.Abstractions.Models.AuthService;
    using RacoonNotes.Abstractions.Services;
    using RacoonNotes.MongoDbConnector.Mappers.AuthService;
    using RacoonNotes.MongoDbConnector.Repositories;
    using System;
    using System.Threading.Tasks;

    public class AuthDataService : IAuthDataService
    {
        private readonly IAuthServiceRepository _authServiceRepository;
        private readonly IUserMapper _userMapper;

        public AuthDataService(IAuthServiceRepository authServiceRepository, IUserMapper userMapper)
        {
            _authServiceRepository = authServiceRepository;
            _userMapper = userMapper;
        }
        public async Task<string> AddUserAsync(User user)
        {
            var mappedUser = _userMapper.Map(user);
            var utcNow = DateTime.UtcNow;
            mappedUser.RegistrationDate = utcNow;
            mappedUser.LastLoginDate = utcNow;
            await _authServiceRepository.CreateAsync(mappedUser);
            return mappedUser.Id;
        }

        public async Task<User> GetUserAsync(string id)
        {
            return _userMapper.Map(await _authServiceRepository.GetByIdAsync(id));
        }

        public async Task<bool> IsUserExistByEmailAsync(string email)
        { 
            return await _authServiceRepository.IsUserExistsByEmailAsync(email);
        }

        public async Task<bool> IsUserExistByUsernameAsync(string username)
        {
            return await _authServiceRepository.IsUserExistsByUsernameAsync(username);
        }
    }
}
