namespace RacoonNotes.MongoDbConnector.Repositories
{
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;
    using RacoonNotes.MongoDbConnector.Models;
    using RacoonNotes.MongoDbConnector.Models.AuthService;
    using System.Threading.Tasks;

    internal class AuthServiceRepository : BaseRepository<DbUser>, IAuthServiceRepository
    {
        public AuthServiceRepository(IMongoClient client, IOptions<MongoDbSettings> settings)
            : base(client, settings, "users") { }

        public async Task<bool> IsUserExistsByEmailAsync(string email)
        {
            return await _collection.Find(_ => _.Email == email).CountDocumentsAsync() > 0;
        }

        public async Task<bool> IsUserExistsByUsernameAsync(string username)
        {
            return await _collection.Find(_ => _.Name == username).CountDocumentsAsync() > 0;
        }
    }
}
