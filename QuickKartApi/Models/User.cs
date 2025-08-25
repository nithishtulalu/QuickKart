using MongoDB.Bson.Serialization.Attributes;

namespace QuickKartApi.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Username")]
        public string UserName { get; set; }
        [BsonElement("Passwordhash")]
        public string PasswordHash {  get; set; }

        [BsonElement("Role")]
        public string Role {  get; set; }

        [BsonElement("Address")]
        public string Address {  get; set; }

        [BsonElement("Phone")]
        public string Phone {  get; set; }

    }
}
