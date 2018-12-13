using ATS.Messaging.Abstractions;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Messaging.Kafka.Consumer
{
    public class AvroKafkaConsumer : BaseKafkaConsumer
    {
        private readonly AvroSerdeProvider _avroProvider;

        public AvroKafkaConsumer(IOptions<MessagingOptions> options,
            ILogger<AvroKafkaConsumer> logger) : base(options, logger)
        {
            var avroConfig = new AvroSerdeProviderConfig { SchemaRegistryUrl = options.Value.SchemeRegistry };
            _avroProvider = new AvroSerdeProvider(avroConfig);
        }

        protected override DeserializerGenerator<TMessage> GetDeserializer<TMessage>()
            => _avroProvider.GetDeserializerGenerator<TMessage>();
    }
}
