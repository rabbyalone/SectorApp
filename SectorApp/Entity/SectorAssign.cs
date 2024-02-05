using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SectorApp.Entity
{
    public class SectorAssign
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsAgreed { get; set; }
        public List<Sector> Sectors { get; set; } = new List<Sector>();
    }
}
