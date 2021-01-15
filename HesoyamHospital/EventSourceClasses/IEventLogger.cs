using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourceClasses
{
    interface IEventLogger
    {
        void log(Event item);
    }
}
