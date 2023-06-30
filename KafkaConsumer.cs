using Confluent.Kafka;

namespace EventHubsWithKafka
{
    /// <summary>
    /// https://github.com/confluentinc/confluent-kafka-dotnet#basic-consumer-example
    /// </summary>
    public class KafkaConsumer
    {
        private EventHubContext context;

        public KafkaConsumer(EventHubContext context)
        {
            this.context = context;
        }

        public async Task RunAsync()
        {
            var conf = new ConsumerConfig
            {
                GroupId = "test-consumer-group",
                
                // Start Changes from sample
                BootstrapServers = context.BootstrapServer,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = "$ConnectionString",
                SaslPassword = context.ConnectionString,
                // End Changes from sample

                // Note: The AutoOffsetReset property determines the start offset in the event
                // there are not yet any committed offsets for the consumer group for the
                // topic/partitions of interest. By default, offsets are committed
                // automatically, so in this example, consumption will only start from the
                // earliest message in the topic 'my-topic' the first time you run the program.
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var c = new ConsumerBuilder<Ignore, string>(conf).Build())
            {
                // Start Changes from sample
                c.Subscribe(context.Topic);
                // End Changes from sample

                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) => {
                    e.Cancel = true; // prevent the process from terminating.
                    cts.Cancel();
                };

                try
                {
                    while (true)
                    {
                        try
                        {
                            var cr = c.Consume(cts.Token);
                            // Start Changes from sample
                            Console.WriteLine($"Consumed message '{cr.Message.Value}' at: '{cr.TopicPartitionOffset}'.");
                            // End Changes from sample
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Error occured: {e.Error.Reason}");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Ensure the consumer leaves the group cleanly and final offsets are committed.
                    c.Close();
                }
            }
        }
    }
}
