using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SectorApp.Entity
{

    public class Sector
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public List<GroupOption> Sectors { get; set; } = new List<GroupOption>();
    }

    public class GroupOption
    {
        public string Value { get; set; }
        public string Label { get; set; }
    }

}
