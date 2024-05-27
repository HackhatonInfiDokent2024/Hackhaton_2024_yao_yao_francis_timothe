

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProjectWorkflow.DataAccess.Models
{
    public class Action
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("Description")]
        public string Description { get; set; } = string.Empty;
    }
}
