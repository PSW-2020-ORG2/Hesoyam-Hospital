namespace Authentication.DTOs
{
    public class PatientDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Jmbg { get; set; }
        public long PatientId { get; set; }

        public PatientDTO()
        {
        }

        public PatientDTO(string name, string surname, string jmbg, long patientId) 
        {
            Name = name;
            Surname = surname;
            Jmbg = jmbg;
            PatientId = patientId;
        }
    }
}
