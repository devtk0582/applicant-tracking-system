using System;

namespace ATS.Messaging.Abstractions
{
    public interface IMessageConsumer
    {
        void StartConsuming<TMessage, TError>(Action<TMessage> onSuccess, Action<TError> onFailure);
    }
}
