namespace SectorApp.Config
{
    public class DbSettings
    {
        public string MongoConnection { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }
}
