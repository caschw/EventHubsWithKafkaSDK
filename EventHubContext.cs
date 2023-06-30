namespace EventHubsWithKafka
{
    public class EventHubContext
    {
        public string BootstrapServer = $"{Cluster}.servicebus.windows.net:9093";

        /// <summary>
        /// The connection string for the EVENT HUBS INSTANCE connection string from the Shared Access Policies section 
        /// </summary>
        public string ConnectionString = "";

        /// <summary>
        /// The Event Hub Namespace name 
        /// </summary>
        public static string Cluster = "";

        /// <summary>
        /// The Event Hub Instance name
        /// </summary>
        public string Topic = "";
    }
}
