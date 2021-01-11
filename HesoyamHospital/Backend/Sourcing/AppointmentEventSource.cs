using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Sourcing.Events;

namespace Backend.Sourcing
{
    public class AppointmentEventSource : IEventSource<AppointmentEvent>
    {
        public void log(AppointmentEvent entityEvent)
        {
            throw new NotImplementedException();
        }
    }
}
