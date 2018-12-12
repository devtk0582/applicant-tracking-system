using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Messaging.Abstractions
{
    public interface IMessageProducer<TMessage>
    {
        void Produce(string topic, TMessage message);
        Task ProduceAsync(string topic, TMessage message);
    }
}
