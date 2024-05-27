

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProjectWorkflow.DataAccess.Models
{
    public class Field
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("Type")]
        public string Type { get; set; } = string.Empty;
    }
}
