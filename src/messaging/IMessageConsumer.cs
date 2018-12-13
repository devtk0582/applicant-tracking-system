using System;

namespace ATS.Messaging.Abstractions
{
    public interface IMessageConsumer
    {
        void StartConsuming<TMessage, TError>(string topic, Action<TMessage> onSuccess, Action<TError> onFailure);
        void StopConsuming();
    }
}
