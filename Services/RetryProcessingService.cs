using KafkaDemo.Helpers.Kafka;
using KafkaDemo.Inputs;
using Newtonsoft.Json;
using System;

namespace KafkaDemo.Services
{
    public class RetryProcessingService
    {
        public static IKafkaProducer<KafkaRetry<Input>> Producer;

        public static void Handler(KafkaRetry<Input> input)
        {
            var refType = input.RefType;
            var retryCount = input.RetryCount;
            switch (refType)
            {
                case RefType.Retry1:
                    {
                        if (retryCount > 0)
                        {
                            if (DateTime.Now >= input.RetryOn)
                            {
                                System.Console.WriteLine($"Got message from Retry Kafka: {input.Request.Message}");
                                var extraData = JsonConvert.DeserializeObject<Retry1Extra>(input.ExtraData);
                                System.Console.WriteLine(
                                    $"Got extra data from Retry Kafka. Extra1:{extraData.Extra1}, Extra2:{extraData.Extra2}");
                            }
                            else
                            {
                                System.Console.WriteLine($"Resend to Queue {DateTime.Now}");
                                Producer.SendMessage(input);
                            }
                        }
                        break;
                    }
                case RefType.Retry2:
                    {
                        // TODO Implement type 2
                        break;
                    }

            }
        }
    }
}
