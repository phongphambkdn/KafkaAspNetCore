namespace KafkaDemo.Helpers
{
    public class AppSettings
    {
        public Kafka Kafka { get; set; }
    }

    public class Kafka
    {
        public string BootstrapServers { get; set; }
        public string Topic { get; set; }
        public string GroupId { get; set; }
    }
}
