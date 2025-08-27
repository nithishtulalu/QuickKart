using MongoDB.Bson.Serialization.Attributes;

namespace QuickKartApi.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("productName")]
        public string ProductName { get; set; }
        [BsonElement("productDescription")]
        public string ProductDescription { get; set; }
        [BsonElement("price")]
        public decimal Price {  get; set; }
        [BsonElement("sellerId")]
        public string SellerId {  get; set; }
    }
}
