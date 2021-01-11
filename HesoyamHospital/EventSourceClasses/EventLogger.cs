using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourceClasses
{
    public  class EventLogger : IEventLogger
    {
        private readonly string SHOULD_LOG_ENV_VAR_NAME = "shouldLogEvents";

        public void log(Event item)
        {
            if (ShouldLog()) item.Log();
      
        }

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
