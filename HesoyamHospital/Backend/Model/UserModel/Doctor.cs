using Backend.Model.DoctorModel;
using System;

namespace Backend.Model.UserModel
{
    public class Doctor : Employee
    {
        public virtual Room Office { get; set; }
        public DoctorType Specialisation { get; set; }
        public virtual TimeTable TimeTable { get; set; }

        public Doctor(  string userName, 
                        string password, 
                        DateTime dateCreated, 
                        string name, 
                        string surname, 
                        string middleName,
                        string jmbg,
                        Sex sex, 
                        DateTime dateOfBirth, 
                        string uidn, 
                        Address address, 
                        string homePhone, 
                        string cellPhone, 
                        string email1, 
                        string email2, 
                        TimeTable timeTable, 
                        Hospital hospital, 
                        Room office, 
                        DoctorType specialisation) 
            : base(hospital, userName, password, dateCreated, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            Office = office;
            Specialisation = specialisation;
            TimeTable = timeTable;
        }

        public Doctor(string userName,
                        string password,
                        string name,
                        string surname,
                        string middleName,
                        string jmbg,
                        Sex sex,
                        DateTime dateOfBirth,
                        string uidn,
                        Address address,
                        string homePhone,
                        string cellPhone,
                        string email1,
                        string email2,
                        TimeTable timeTable,
                        Hospital hospital,
                        Room office,
                        DoctorType specialisation)
            : base(hospital, userName, password, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            Office = office;
            Specialisation = specialisation;
            TimeTable = timeTable;
        }

        public Doctor(  long id,
                        UserID uid, 
                        string userName, 
                        string password, 
                        DateTime dateCreated, 
                        string name, 
                        string surname, 
                        string middleName, 
                        string jmbg,
                        Sex sex, 
                        DateTime dateOfBirth, 
                        string uidn, 
                        Address address, 
                        string homePhone, 
                        string cellPhone, 
                        string email1, 
                        string email2, 
                        TimeTable timeTable, 
                        Hospital hospital, 
                        Room office, 
                        DoctorType specialisation) 
            : base(id, uid, hospital, userName, password, dateCreated, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            Office = office;
            Specialisation = specialisation;
            TimeTable = timeTable;
        }

        public Doctor(long id) : base(id) { }

        public bool IsGeneralPractitian()
        {
            if (Specialisation == DoctorType.GENERAL_PRACTITIONER) return true;
            return false;
        }


    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    