using KafkaDemo.Inputs;

namespace KafkaDemo.Services
{
    public class ProcessingService
    {
        public static void Handler(Input input)
        {
            System.Console.WriteLine($"Got message from Kafka: {input.Message}");
        }
    }
}
