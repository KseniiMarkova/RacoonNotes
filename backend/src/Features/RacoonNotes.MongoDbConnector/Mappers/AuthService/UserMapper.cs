namespace RacoonNotes.MongoDbConnector.Mappers.AuthService
{
    using RacoonNotes.Abstractions.Models.AuthService;
    using RacoonNotes.MongoDbConnector.Models.AuthService;
    using System;

    internal class UserMapper : IUserMapper
    {
        public DbUser Map(User source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return new DbUser
            {
                Id = source.Id,
                Email = source.Email,
                Name = source.Name,
                HashedPassword = source.HashedPassword,
                Role = source.Role,
                RegistrationDate = source.RegistrationDate,
                RegistrationCountry = source.RegistrationCountry,
                LastLoginDate = source.LastLoginDate,
                IsBanned = source.IsBanned,
                IsDeleted = source.IsDeleted
            };
        }

        public User Map(DbUser source)
        {
            if (source == null)
            {
                return new User();
            }

            return new User
            {
                Id = source.Id,
                Email = source.Email,
                Name = source.Name,
                HashedPassword = source.HashedPassword,
                Role = source.Role,
                RegistrationDate = source.RegistrationDate,
                RegistrationCountry = source.RegistrationCountry,
                LastLoginDate = source.LastLoginDate,
                IsBanned = source.IsBanned,
                IsDeleted = source.IsDeleted
            };
        }
    }
}
