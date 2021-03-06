﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EventSourceClasses
{
    public abstract class Event
    {
        public abstract void Log();

        protected void SendRequest(string apiEndPoint, string serializedObject)
        {
            var client = new HttpClient();
            client.PostAsync(apiEndPoint, new StringContent(serializedObject, Encoding.UTF8, "application/json"));
        }

        protected string SerializeObject()
        {
            return JsonConvert.SerializeObject(this);
        }


        protected void LogObject(string apiEndPoint)
        {
            string serializedObject = SerializeObject();
            SendRequest(apiEndPoint, serializedObject);
        }
    }
}
