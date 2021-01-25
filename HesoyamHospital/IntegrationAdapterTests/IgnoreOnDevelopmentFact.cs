using System;
using Xunit;

namespace IntegrationAdapterTests
{
    public sealed class IgnoreOnDevelopmentFact : FactAttribute
    {
        public IgnoreOnDevelopmentFact()
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development"))
            {
                Skip = "Ignore on Development";
            }
        }
    }
}
