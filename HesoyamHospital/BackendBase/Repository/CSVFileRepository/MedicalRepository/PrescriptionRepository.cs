using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class PrescriptionRepository : CSVRepository<Prescription, long>, IPrescriptionRepository, IEagerCSVRepository<Prescription, long>
    {
        private const string ENTITY_NAME = "Prescription";
        private IDoctorRepository _doctorRepository;
        private IMedicineRepository _medicineRepository;

        public PrescriptionRepository(ICSVStream<Prescription> stream, ISequencer<long> sequencer, IDoctorRepository doctorRepository, IMedicineRepository medicineRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Prescription>())
        {
            _doctorRepository = doctorRepository;
            _medicineRepository = medicineRepository;
        }

        public IEnumerable<Prescription> GetAllEager()
        {
            IEnumerable<Prescription> prescriptions = GetAll();

            IEnumerable<Medicine> medicines = _medicineRepository.GetAll();
            IEnumerable<Doctor> doctors = _doctorRepository.GetAll();

            Bind(prescriptions);

            return prescriptions;
        }

        private void Bind(IEnumerable<Prescription> prescriptions)
        {
            var medicines = _medicineRepository.GetAll();
            BindPrescriptionsWithMedicine(prescriptions, medicines);

            var doctors = _doctorRepository.GetAll();
            BindPrescriptionsWithDoctor(prescriptions, doctors);
        }

        private void BindPrescriptionsWithDoctor(IEnumerable<Prescription> prescriptions, IEnumerable<Doctor> doctors)
            => prescriptions.ToList().ForEach(prescription => prescription.Doctor = doctors.SingleOrDefault(doctor => doctor.GetId() == prescription.Doctor.GetId()));

        //medicine
        private void BindPrescriptionsWithMedicine(IEnumerable<Prescription> prescriptions, IEnumerable<Medicine> medicines)
        {

            foreach (Prescription prescription in prescriptions)
            {
                Dictionary<Medicine, TherapyDose> dict = new Dictionary<Medicine, TherapyDose>();
                    foreach(Medicine medicine in prescription.Medicine.Keys)
                    {
                        Medicine med = medicines.SingleOrDefault(m => m.GetId() == medicine.GetId());
                        dict.Add(med,prescription.Medicine[medicine]);         
                    }
                prescription.Medicine = dict;
            }
                
        }

        public Prescription GetEager(long id)
            => GetAllEager().SingleOrDefault(prescription => prescription.GetId() == id);
    }
}
