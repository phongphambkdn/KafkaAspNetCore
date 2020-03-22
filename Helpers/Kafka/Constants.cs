using System;

namespace KafkaDemo.Helpers.Kafka
{
    public class KafkaSetting
    {
        public string BootstrapServers { get; set; }
        public string Topic { get; set; }
        public string ExceptionTopic { get; set; }
        public string GroupId { get; set; }
        public string ExceptionGroupId { get; set; }
    }

    public class KafkaRetry<T>
    {
        public int RetryCount { get; set; }
        public DateTime RetryOn { get; set; }
        public RefType RefType { get; set; }
        public T Request { get; set; }
        public string ExtraData { get; set; }
    }

    public class Retry1Extra
    {
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }

    public enum RefType
    {
        Retry1,
        Retry2
    }
}
