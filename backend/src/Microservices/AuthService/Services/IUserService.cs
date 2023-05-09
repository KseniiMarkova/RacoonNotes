namespace AuthService.Services
{
    using AuthService.Models.Messages;

    public interface IUserService
    {
        Task<string> AddNewUserAsync(CreateUserRequestMessage userRequest);
        Task<GetUserByIdResponceMessage> GetUserByIdAsync(GetUserByIdRequestMessage userRequest);
    }
}
