using ATS.Messaging.Abstractions;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Messaging.Kafka.Consumer
{
    public class DefaultKafkaConsumer : BaseKafkaConsumer
    {
        public DefaultKafkaConsumer(IOptions<MessagingOptions> options,
            ILogger<DefaultKafkaConsumer> logger) : base(options, logger) { }

        protected override DeserializerGenerator<TMessage> GetDeserializer<TMessage>()
        {
            return (forKey) =>
            {
                return (topic, data, isNull) =>
                {
                    if (data == null || data.Length == 0)
                        return default(TMessage);

                    var jsonData = Encoding.UTF8.GetString(data.ToArray());
                    try
                    {
                        return JsonConvert.DeserializeObject<TMessage>(jsonData);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Failed to deserialize message. Data: {jsonData}");
                        return default(TMessage);
                    }
                };
            };
        }
    }
}
