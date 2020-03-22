using Confluent.Kafka;
using Newtonsoft.Json;
using System;

namespace KafkaDemo.Helpers
{
    public interface IKafkaProducer<T>
    {
        bool SendMessage(T message);
    }

    public class KafkaProducer<T> : IKafkaProducer<T>, IDisposable
    {
        private readonly string _topic;
        private readonly IProducer<Null, string> _producer;

        public KafkaProducer(string bootstrapServers, string topic)
        {
            _topic = topic;

            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public bool SendMessage(T message)
        {
            try
            {
                _producer.ProduceAsync(_topic, new Message<Null, string> { Value = JsonConvert.SerializeObject(message) }).Wait();

                return true;
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");

                return false;
            }
        }

        public void Dispose()
        {
            _producer.Flush(TimeSpan.FromSeconds(10));
            _producer.Dispose();
        }
    }
}
