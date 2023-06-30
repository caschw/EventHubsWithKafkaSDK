using Confluent.Kafka;
using EventHubsWithKafka.Kafka.Helpers;

namespace EventHubsWithKafka.Kafka
{
    /// <summary>
    /// https://github.com/confluentinc/confluent-kafka-dotnet#basic-producer-examples
    /// </summary>
    public class Producer
    {
        private EventHubContext context;

        public Producer(EventHubContext context)
        {
            this.context = context;
        }

        public async Task RunAsync(string message)
        {
            var config = new ProducerConfig
            {
                // Start Changes from sample
                BootstrapServers = context.BootstrapServer,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = "$ConnectionString",
                SaslPassword = context.ConnectionString
                // End Changes from sample
            };

            // If serializers are not specified, default serializers from
            // `Confluent.Kafka.Serializers` will be automatically used where
            // available. Note: by default strings are encoded as UTF8.
            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    // Start Changes from sample
                    var dr = await p.ProduceAsync(context.Topic, new Message<Null, string> { Value = message });
                    // End Changes from sample

                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }
    }
}
