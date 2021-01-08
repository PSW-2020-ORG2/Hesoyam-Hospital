//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Text;
//using EventSourceClasses;
//using Newtonsoft.Json;

//namespace EventSourceClasses.Appointments
//{
//    public class AppointmentEventLogger : EventLogger<AppointmentEvent>
//    {
//        private readonly string END_POINT_ENV_VAR_NAME = "appointmentEventLoggerURL";

//        public override void log(Event item)
//        {
//            if (ShouldLog())
//            {
//                string serializedObject = JsonConvert.SerializeObject(item);
//                var client = new HttpClient();
//                client.PostAsync(Environment.GetEnvironmentVariable(END_POINT_ENV_VAR_NAME), new StringContent(serializedObject, Encoding.UTF8, "application/json"));
//            }
//        }

//        public override void log(AppointmentEvent item)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
