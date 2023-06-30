using System.Text.Json;

namespace EventHubsWithKafka
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var context = new EventHubContext();

            var p = new KafkaProducer(context);
            await p.RunAsync(JsonSerializer.Serialize(new SampleMessage()));
            
            var c = new KafkaConsumer(context);
            await c.RunAsync();
        }
    }
}