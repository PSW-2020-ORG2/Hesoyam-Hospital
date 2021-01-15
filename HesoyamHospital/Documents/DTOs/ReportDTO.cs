using System;

namespace Documents.DTOs
{
    public class ReportDTO
    {
        public DateTime DateTimeCreated { get; set; }
        public string DoctorFullName { get; set; }
        public string DoctorSpecialisation { get; set; }
        public string Diagnosis { get; set; }
        public string Comment { get; set; }

        public ReportDTO(DateTime dateTimeCreated, string doctorFullName, string doctorSpecialisation, string diagnosis, string comment)
        {
            DateTimeCreated = dateTimeCreated;
            DoctorFullName = doctorFullName;
            DoctorSpecialisation = doctorSpecialisation;
            Diagnosis = diagnosis;
            Comment = comment;
        }
    }
}
