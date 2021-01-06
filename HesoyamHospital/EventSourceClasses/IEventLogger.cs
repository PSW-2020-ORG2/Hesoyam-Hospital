using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourceClasses
{
    interface IEventLogger<T>
    {
        void log(T item);
    }
}
