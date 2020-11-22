using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Documents
{
    public class SearchCriteria
    {
        public bool ShouldSearchReports { get; set; }
        public bool ShouldSearchPrescriptions { get; set; }
        public TimeInterval TimeInterval { get; set; }
        public string DoctorName { get; set; }
        public string Diagnosis { get; set; }
        public string MedicineName { get; set; }
        public string Comment { get; set; }

        public SearchCriteria(bool shouldSearchReports, bool shouldSearchPrescriptions, TimeInterval timeInterval, string doctorName, string diagnosis, string medicineName, string comment)
        {
            ShouldSearchReports = shouldSearchReports;
            ShouldSearchPrescriptions = shouldSearchPrescriptions;
            TimeInterval = timeInterval;
            DoctorName = doctorName;
            Diagnosis = diagnosis;
            MedicineName = medicineName;
            Comment = comment;
        }
    }
}
