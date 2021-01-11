using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourceClasses.Appointments
{
    public enum AppointmentEventType
    {
        CREATED,
        MODIFIED,
        DELETED,
        CANCELLED
    }
}
