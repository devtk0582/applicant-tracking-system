using ATS.Messaging.Abstractions;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Messaging.Kafka.Producer
{
    public class DefaultKafkaProducer<TMessage> : BaseKafkaProducer<TMessage>
    {
        public DefaultKafkaProducer(IOptions<MessagingOptions> options, 
            ILogger<DefaultKafkaProducer<TMessage>> logger) : base(options, logger) { }

        protected override Producer<Null, TMessage> GetProducer()
        {
            var producerConfig = new ProducerConfig { BootstrapServers = _options.Servers };

            return new Producer<Null, TMessage>(producerConfig, null);
        }
    }
}
