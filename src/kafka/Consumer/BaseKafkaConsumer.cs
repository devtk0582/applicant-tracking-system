using ATS.Messaging.Abstractions;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Messaging.Kafka.Consumer
{
    public abstract class BaseKafkaConsumer : IMessageConsumer
    {
        protected readonly ILogger<BaseKafkaConsumer> _logger;
        protected readonly MessagingOptions _options;

        private bool _isRunning = false;
        
        public BaseKafkaConsumer(IOptions<MessagingOptions> options,
            ILogger<BaseKafkaConsumer> logger)
        {
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
            _logger = logger;
        }

        public void StartConsuming<TMessage, TError>(string topic, Action<TMessage> onSuccess, Action<TError> onFailure)
        {
            if (onSuccess == null) throw new ArgumentNullException(nameof(onSuccess));
            if (onFailure == null) throw new ArgumentNullException(nameof(onFailure));

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = _options.Servers,
                GroupId = _options.ConsumerSettings?.GroupId,
                EnableAutoCommit = _options.ConsumerSettings?.EnableAutoCommit,
                AutoOffsetReset = (AutoOffsetResetType)Enum.Parse(typeof(AutoOffsetResetType), _options.ConsumerSettings?.AutoOffsetReset)
            };

            var timeout = TimeSpan.FromMilliseconds(_options.ConsumerSettings?.Timeout ?? 100);

            using (var consumer = new Consumer<Null, TMessage>(consumerConfig, null, GetDeserializer<TMessage>()))
            {
                consumer.Subscribe(topic);

                consumer.OnError += (_, e) =>
                {
                    _logger.LogError($"Kafka consumer failed to consume a message. Reason: {e.Reason}. Code: {e.Code}.");
                };

                _isRunning = true;
                while(_isRunning)
                {
                    var consumeResult = consumer.Consume(timeout);
                    if (consumeResult == null)
                        continue;

                    onSuccess(consumeResult.Message.Value);
                    consumer.Commit(consumeResult);
                }
            };

            _logger.LogInformation("Kafka consumer stopped listening");
        }

        public void StopConsuming()
        {
            _isRunning = false;
        }

        protected abstract DeserializerGenerator<TMessage> GetDeserializer<TMessage>();
    }
}
