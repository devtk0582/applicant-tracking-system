using ATS.Messaging.Abstractions;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Messaging.Kafka.Producer
{
    public class AvroKafkaProducer<TMessage> : BaseKafkaProducer<TMessage>
    {
        public AvroKafkaProducer(IOptions<MessagingOptions> options, 
            ILogger<AvroKafkaProducer<TMessage>> logger) : base(options, logger) { }

        protected override Producer<Null, TMessage> GetProducer()
        {
            var producerConfig = new ProducerConfig { BootstrapServers = _options.Servers };
            var avroProvider = new AvroSerdeProvider(new AvroSerdeProviderConfig { SchemaRegistryUrl = _options.SchemeRegistry });

            return new Producer<Null, TMessage>(producerConfig, null, avroProvider.GetSerializerGenerator<TMessage>());
        }
    }
}
