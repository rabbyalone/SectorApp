using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SectorApp.Entity
{
    public class SectorAssign
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsAgreed { get; set; }
        public List<GroupOption> Sectors { get; set; } = new List<GroupOption>();
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; } = string.Empty;
    }
}
