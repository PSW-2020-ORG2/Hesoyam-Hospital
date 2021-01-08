using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EventSourceClasses.Authentication
{
    public class PatientEventLogger : EventLogger<SelectedDoctorEvent>
    {
        private readonly string END_POINT_ENV_VAR_NAME = "selectedDoctorEventLoggerURL";

        public override void log(SelectedDoctorEvent item)
        {
            if (ShouldLog())
            {
                string serializedObject = JsonConvert.SerializeObject(item);
                var client = new HttpClient();
                client.PostAsync(Environment.GetEnvironmentVariable(END_POINT_ENV_VAR_NAME), new StringContent(serializedObject, Encoding.UTF8, "application/json"));
            }
        }
    }
}
