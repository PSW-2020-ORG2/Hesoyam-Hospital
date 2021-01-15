using System;

namespace Documents.DTOs
{
    public class ReportDTO
    {
        public string DateTimeCreated { get; set; }
        public string DoctorFullName { get; set; }
        public string DoctorSpecialisation { get; set; }
        public string Diagnosis { get; set; }
        public string Comment { get; set; }

        public ReportDTO(DateTime dateTimeCreated, string doctorFullName, string doctorSpecialisation, string diagnosis, string comment)
        {
            DateTimeCreated = dateTimeCreated.ToString("dd.MM.yyyy");
            DoctorFullName = doctorFullName;
            DoctorSpecialisation = doctorSpecialisation;
            Diagnosis = diagnosis;
            Comment = comment;
        }
    }
}
