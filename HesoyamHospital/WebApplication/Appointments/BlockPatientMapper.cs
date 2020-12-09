using Backend;
using Backend.Model.UserModel;
using WebApplication.Appointments.DTOs;

namespace WebApplication.Appointments
{
    public static class BlockPatientMapper
    {
        public static BlockPatientDTO toDto(long id, int count)
        {
            Patient patient = AppResources.getInstance().patientRepository.GetByID(id);
            if (patient == null) return null;
            return new BlockPatientDTO(patient.UserName, count, patient.FullName);
        }
    }
}
