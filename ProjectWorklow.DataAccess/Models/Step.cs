using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProjectWorkflow.DataAccess.Models
{
    public class Step
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("Description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("RequiredFields")]
        public List<Field> RequiredFields { get; set; } = [];

        [BsonElement("Participants")]
        public Participants Participant { get; set; } = new Participants();

        [BsonElement("PossibleActions")]
        public List<Action> PossibleActions { get; set; } = [];
    }
}
