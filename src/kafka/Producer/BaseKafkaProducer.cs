using ATS.Messaging.Abstractions;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace ATS.Messaging.Kafka.Producer
{
    public abstract class BaseKafkaProducer<TMessage> : IMessageProducer<TMessage>, IDisposable
    {
        private readonly ILogger<BaseKafkaProducer<TMessage>> _logger;
        protected readonly MessagingOptions _options;
        private readonly Producer<Null, TMessage> _producer;

        public BaseKafkaProducer(IOptions<MessagingOptions> options,
            ILogger<BaseKafkaProducer<TMessage>> logger)
        {
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
            _logger = logger;
            _producer = GetProducer();
        }

        public void Produce(string topic, TMessage message)
        {
            if (string.IsNullOrEmpty(topic) || message == null)
                throw new ArgumentNullException();

            _producer.ProduceAsync(topic, new Message<Null, TMessage> { Value = message })
                .ContinueWith(task =>
                {
                    if (task.IsFaulted)
                        _logger.LogError(task.Exception, "Failed to produce message");
                }).GetAwaiter().GetResult();
        }

        public async Task ProduceAsync(string topic, TMessage message)
        {
            if (string.IsNullOrEmpty(topic) || message == null)
                throw new ArgumentNullException();

            await _producer.ProduceAsync(topic, new Message<Null, TMessage> { Value = message })
                .ContinueWith(task =>
                {
                    if (task.IsFaulted)
                        _logger.LogError(task.Exception, "Failed to produce message");
                });
        }

        protected abstract Producer<Null, TMessage> GetProducer();

        public void Dispose()
        {
            _producer?.Dispose();
        }
    }
}
