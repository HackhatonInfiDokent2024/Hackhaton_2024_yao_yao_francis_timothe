
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProjectWorkflow.DataAccess.Models
{
    public class Participants
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("EmailRequester")]
        public string EmailRequester { get; set; } = "yao@gmail.com";
        [BsonElement("EmailValidator")]
        public string EmailValidator { get; set; } = string.Empty;
        [BsonElement("EmailDT")]
        public string EmailDT { get; set; } = string.Empty;
    }
}
