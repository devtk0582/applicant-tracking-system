using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Messaging.Abstractions
{
    public class MessageConsumerSettings
    {
        public string GroupId { get; set; }
        public bool EnableAutoCommit { get; set; }
        public string AutoOffsetReset { get; set; }
        public int Timeout { get; set; }
        public int MaxRetryCount { get; set; }
    }
}
