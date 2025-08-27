using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QuickKartApi.Models
{
    public class Orders
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("customerId ")]
        public string CustomerId {  get; set; }
        [BsonElement("productIds")]
        public List<string> ProductIds { get; set; }
        [BsonElement("orderDate")]
        public DateTime OrderDate { get; set; }
        [BsonElement("totalAmount")]
        public decimal TotalAmount {  get; set; }
        [BsonElement("status")]
        public string Status {  get; set; }
       
    }
}
