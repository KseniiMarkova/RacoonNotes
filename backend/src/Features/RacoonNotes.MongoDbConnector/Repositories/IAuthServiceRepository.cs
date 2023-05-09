namespace RacoonNotes.MongoDbConnector.Repositories
{
    using RacoonNotes.Abstractions.Repositories;
    using RacoonNotes.MongoDbConnector.Models.AuthService;

    public interface IAuthServiceRepository: IBaseRepository<DbUser>
    {
        Task<bool> IsUserExistsByEmailAsync(string email);
        Task<bool> IsUserExistsByUsernameAsync(string username);

    }
}
