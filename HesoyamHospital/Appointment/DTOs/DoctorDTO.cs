namespace Appointments.DTOs
{
    public class DoctorDTO
    {
        public long Id { get; set; }
        public string FullName { get; set; }

        public DoctorDTO() { }

        public DoctorDTO(long id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }
    }
}
