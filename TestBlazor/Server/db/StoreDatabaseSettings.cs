namespace TestBlazor.Server.db
{
    public class StoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string StoreCollectionName { get; set; } = null!;
    }
}
