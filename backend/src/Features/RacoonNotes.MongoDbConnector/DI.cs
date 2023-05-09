namespace Microsoft.Extensions.DependencyInjection
{
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;
    using RacoonNotes.Abstractions.Services;
    using RacoonNotes.MongoDbConnector.Mappers.AuthService;
    using RacoonNotes.MongoDbConnector.Models;
    using RacoonNotes.MongoDbConnector.Repositories;
    using RacoonNotes.MongoDbConnector.Services.AuthService;

    public static class MongoDbConnectorCollectionExtensions
    {
        public static IServiceCollection AddMongoDbConnectorDependencyGroup(
             this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient>(serviceProvider =>
            {
                var mongoDbSettings = serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                return new MongoClient(mongoDbSettings.ConnectionString);
            });
            services.AddScoped<IAuthServiceRepository, AuthServiceRepository>();
            services.AddScoped<IUserMapper, UserMapper>();
            services.AddScoped<IAuthDataService, AuthDataService>();

            return services;
        }
    }
}