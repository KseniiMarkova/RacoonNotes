namespace RacoonNotes.MongoDbConnector.Mappers.AuthService
{
    using MongoDbConnector.Models.AuthService;
    using RacoonNotes.Abstractions.Models.AuthService;

    public interface IUserMapper
    {
        DbUser Map(User source);
        User Map(DbUser source);

    }
}
