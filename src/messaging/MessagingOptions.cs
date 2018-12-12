using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Messaging.Abstractions
{
    public class MessagingOptions
    {
        public const string ConfigSection = "Messaging";
        public string Servers { get; set; }
        public string SchemeRegistry { get; set; }
    }
}
