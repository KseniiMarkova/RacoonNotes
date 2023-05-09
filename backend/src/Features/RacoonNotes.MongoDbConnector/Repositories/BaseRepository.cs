namespace RacoonNotes.MongoDbConnector.Repositories
{
    using Microsoft.Extensions.Options;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using RacoonNotes.Abstractions.Repositories;
    using RacoonNotes.MongoDbConnector.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public abstract class BaseRepository<T>: IBaseRepository<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection;

        public BaseRepository(IMongoClient client, IOptions<MongoDbSettings> settings, string collectionName)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id))).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id)), entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id)));
        }
    }
}
