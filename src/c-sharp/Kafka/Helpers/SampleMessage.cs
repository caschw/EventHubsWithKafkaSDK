namespace EventHubsWithKafka.Kafka.Helpers
{
    public class SampleMessage
    {
        public string Timestamp => DateTime.Now.ToString();
        public TempSensor Payload => new TempSensor();
        public string MessageType => "LiquidTempSensorReading";
        public string CorrelationId => Guid.NewGuid().ToString();
    }

    public class TempSensor
    {
        public string Message => "An insightful text interpretation of the temperature";
        public int Temerature => new Random().Next(87, 115);
        public string TemperatureType => "Celcius";
    }
}
