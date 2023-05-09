namespace RacoonNotes.MongoDbConnector.Models.AuthService
{
    using RacoonNotes.Abstractions.Models.AuthService.Enums;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;
    using System;

    public class DbUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string HashedPassword { get; set; }
        public UserRoles Role { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegistrationCountry { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool IsBanned { get; set; }
        public bool IsDeleted { get; set; }
    }
}
