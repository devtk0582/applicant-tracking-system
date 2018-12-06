using Microsoft.AspNetCore.Hosting;
using System;

namespace ATS.Common.Extensions
{
    public static class HostingEnvironmentExtensions
    {
        public static bool IsDebug(this IHostingEnvironment env)
        {
            return env.IsEnvironment("Debug");
        }

        public static bool IsQA(this IHostingEnvironment env)
        {
            return env.IsEnvironment("QA");
        }

        public static bool IsProd(this IHostingEnvironment env)
        {
            return env.IsEnvironment("Prod");
        }
    }
}
