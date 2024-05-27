
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProjectWorkflow.DataAccess.Models
{
    public class Workflow
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("Name")]
        public string Name { get; set; }=string.Empty;
        [BsonElement("Steps")]
        public List<Step> Steps { get; set; } = new List<Step>();
    }
}
