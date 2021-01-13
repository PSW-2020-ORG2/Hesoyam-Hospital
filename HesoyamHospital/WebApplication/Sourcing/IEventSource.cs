using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Sourcing
{
    interface IEventSource<K>
    {
        void log(K entityEvent);
    }
}


/*
 * Controller -> 
 *      IEventSource<AppointmentEvent> eventSource; (Dependency injection)
 * 
 *      eventSource.log(appointmenEvent)
 * 
 * Imamo posebnu klasu
 * AppointmentEventSource : IEventSource<AppointmentEvent>{
 *              ....    ..  .   ..      .   .
 * }
 * 
 * 
 * 
*/