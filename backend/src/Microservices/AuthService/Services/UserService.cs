namespace AuthService.Services
{
    using AuthService.Models.Messages;
    using RacoonNotes.Abstractions.Models.AuthService;
    using RacoonNotes.Abstractions.Models.AuthService.Enums;
    using RacoonNotes.Abstractions.Services;
    using RacoonNotes.Errors.Exceptions;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly IAuthDataService _authDataService;

        public UserService(IAuthDataService authDataService)
        {
            _authDataService = authDataService;
        }
        public async Task<string> AddNewUserAsync(CreateUserRequestMessage userRequest)
        {
            await ValidateCreateUserRequest(userRequest);

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userRequest.Password);
            var user = new User()
            {
                Email = userRequest.Email,
                Name = userRequest.Name,
                RegistrationCountry = userRequest.RegistrationCountry,
                IsBanned = false,
                IsDeleted = false,
                Role = UserRoles.User,
                HashedPassword = hashedPassword,
            };
            return await _authDataService.AddUserAsync(user);
        }

        public async Task<GetUserByIdResponceMessage> GetUserByIdAsync(GetUserByIdRequestMessage userRequest)
        {
            if (userRequest == null)
            {
                throw new ArgumentNullException($"{nameof(userRequest)} is null");
            }

            if (userRequest.UserId == default)
            {
                throw new ArgumentException($"{nameof(userRequest.UserId)} is default");
            }

            var user = await _authDataService.GetUserAsync(userRequest.UserId);
            if (user.Id == default)
            {
                throw new NotFoundException($"{nameof(user)} do not exists with id ${userRequest.UserId}");
            }

            return new GetUserByIdResponceMessage()
            {
                UserId = user.Id,
                UserName = user.Name,
                Email = user.Email,
                IsBanned = user.IsBanned,
            };
        }

        private async Task ValidateCreateUserRequest(CreateUserRequestMessage userRequest)
        {
            if (userRequest == null)
            {
                throw new ArgumentNullException($"{nameof(userRequest)} is null");
            }

            if (string.IsNullOrWhiteSpace(userRequest.Password))
            {
                throw new ArgumentException($"{nameof(userRequest.Password)} is empty");
            }

            if (string.IsNullOrWhiteSpace(userRequest.Name))
            {
                throw new ArgumentException($"{nameof(userRequest.Name)} is empty");
            }

            if (string.IsNullOrWhiteSpace(userRequest.Email))
            {
                throw new ArgumentException($"{nameof(userRequest.Email)} is empty");
            }

            if (await _authDataService.IsUserExistByEmailAsync(userRequest.Email))
            {
                throw new UserAlreadyExistsException($"{nameof(userRequest.Email)}:{userRequest.Email} already taken");
            }

            if (await _authDataService.IsUserExistByUsernameAsync(userRequest.Name))
            {
                throw new UserAlreadyExistsException($"{nameof(userRequest.Name)}:{userRequest.Name} already taken");
            }
        }
    }
}
