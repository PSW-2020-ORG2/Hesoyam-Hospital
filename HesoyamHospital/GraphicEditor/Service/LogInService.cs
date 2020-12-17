using Backend.Model.UserModel;
using Backend.Repository.MySQLRepository.UsersRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphicEditor.Service
{
    public class LogInService
    {
        private ManagerRepository managerRepository;
        private DoctorRepository doctorRepository;
        private PatientRepository patientRepository;
        private SecretaryRepository secretaryRepository;

        List<Patient> patients = new List<Patient>();
        List<Manager> managers = new List<Manager>();
        List<Doctor> doctors = new List<Doctor>();
        List<Secretary> secretaries = new List<Secretary>();

        public LogInService()
        {
            this.managerRepository = Backend.AppResources.getInstance().managerRepository;
            this.doctorRepository = Backend.AppResources.getInstance().doctorRepository;
            this.patientRepository = Backend.AppResources.getInstance().patientRepository;
            this.secretaryRepository = Backend.AppResources.getInstance().secretaryRepository;
        }

        public List<Manager> getAllManagers()
        {
            if (managerRepository.GetAll() == null)
            {
                return null;
            }

            managers = managerRepository.GetAll().ToList();
            return managers;
        }
        public List<Doctor> getAllDoctors()
        {
            if (doctorRepository.GetAll() == null)
            {
                return null;
            }
            doctors = doctorRepository.GetAll().ToList();
            return doctors;
        }
        public List<Patient> getAllPatients()
        {
            if (patientRepository.GetAll() == null)
            {
                return null;
            }

            patients = patientRepository.GetAll().ToList();
            return patients;
        }

        public List<Secretary> getAllSecretaries()
        {
            if (secretaryRepository.GetAll() == null)
            {
                return null;
            }
            secretaries = secretaryRepository.GetAll().ToList();
            return secretaries;
        }

        public Boolean FindPatient(string username, string password)
        {
            foreach (Patient patient in patients)
            {
                if (patient.UserName == username && patient.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean FindSecretary(string username, string password)
        {
            foreach (Secretary secretary in secretaries)
            {
                if (secretary.UserName == username && secretary.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public Boolean FindManager(string username, string password)
        {
            foreach (Manager manager in managers)
            {
                if (manager.UserName == username && manager.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean FindDoctor(string username, string password)
        {
            foreach (Doctor doctor in doctors)
            {
                if (doctor.UserName == username && doctor.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
