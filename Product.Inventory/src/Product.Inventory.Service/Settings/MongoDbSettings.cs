namespace Product.Inventory.Service.Settings
{
    public class MongoDbSettings
    {
        public string Host { get; init; } // Represents the MongoDB host

        public int Port { get; init; } // Represents the MongoDB port

        // Constructs the MongoDB connection string using the specified host and port
        public string ConnectionString => $"mongodb://{Host}:{Port}";
    }
}
