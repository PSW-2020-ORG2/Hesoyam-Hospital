using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourceClasses
{
    public abstract class EventLogger<T> : IEventLogger<T>
    {
        private readonly string SHOULD_LOG_ENV_VAR_NAME = "shouldLogEvents";
        public abstract void log(T item);

        protected bool ShouldLog()
        {
            return getShouldLogEnvVal();
        }

        private bool getShouldLogEnvVal()
        {
            bool shouldLog;
            if (!bool.TryParse(Environment.GetEnvironmentVariable(SHOULD_LOG_ENV_VAR_NAME), out shouldLog))
                shouldLog = false;

            return shouldLog;
        }
    }
}
