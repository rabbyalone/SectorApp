using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SectorApp.Entity
{

    public class Sector
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public List<ChildSector> Sectors { get; set; } = new List<ChildSector>();
    }
    public class ChildSector
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
