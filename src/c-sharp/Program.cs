using System.Text.Json;

namespace EventHubsWithKafka
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var context = new Kafka.Helpers.EventHubContext();

            var p = new Kafka.Producer(context);
            await p.RunAsync(JsonSerializer.Serialize(new Kafka.Helpers.SampleMessage()));
            
            var c = new Kafka.Consumer(context);
            await c.RunAsync();
        }
    }
}