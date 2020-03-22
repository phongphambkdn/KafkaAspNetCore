using System;
using KafkaDemo.Helpers.Kafka;
using KafkaDemo.Inputs;
using Newtonsoft.Json;

namespace KafkaDemo.Services
{
    public class ProcessingService
    {
        public static IKafkaProducer<KafkaRetry<Input>> Producer;

        public static void Handler(Input input)
        {
            System.Console.WriteLine($"Got message from Kafka: {input.Message}");

            if (input.Message == "Retry")
            {
                var extraData = new Retry1Extra { Extra1 = "Extra1", Extra2 = "Extra2" };
                var message = new KafkaRetry<Input>
                {
                    RetryOn = DateTime.Now.AddSeconds(10),
                    RetryCount = 1,
                    Request = input,
                    RefType = RefType.Retry1,
                    ExtraData = JsonConvert.SerializeObject(extraData)
                };

                Producer.SendMessage(message);
            }
        }
    }
}
