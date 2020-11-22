using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.UserModel
{
    public class Survey : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private Doctor _doctor;
        public Doctor Doctor { get => _doctor; set { _doctor = value; _doctorID = value.Id; } }

        private long _doctorID;
        public long DoctorID { get => _doctorID; set => _doctorID = value; }

        private Section _staffSection;
        public Section StaffSection { get => _staffSection; set { _staffSection = value; _staffSectionID = value.Id; } }

        private long _staffSectionID;
        public long StaffSectionID { get => _staffSectionID; set => _staffSectionID = value; }

        private Section _doctorSection;
        public Section DoctorSection { get => _doctorSection; set { _doctorSection = value; _doctorSectionID = value.Id; } }

        private long _doctorSectionID;
        public long DoctorSectionID { get => _doctorSectionID; set => _doctorSectionID = value; }

        private Section _hygieneSection;
        public Section HygieneSection { get => _hygieneSection; set { _hygieneSection = value; _hygieneSectionID = value.Id; } }

        private long _hygieneSectionID;
        public long HygieneSectionID { get => _hygieneSectionID; set => _hygieneSectionID = value; }

        private Section _equipmentSection;
        public Section EquipmentSection { get => _equipmentSection; set { _equipmentSection = value; _equipmentSectionID = value.Id; } }

        private long _equipmentSectionID;
        public long EquipmentSectionID { get => _equipmentSectionID; set => _equipmentSectionID = value; }

        public Survey()
        {
        }

        public Survey(long id) {

            _id = id;

        }

        public Survey(long id, Doctor doctor, Section staffSection, Section doctorSection, Section hygieneSection, Section equipmentSection)
        {

            _id = id;
            _doctor = doctor;
            _doctorID = doctor.Id;
            _staffSection = staffSection;
            _staffSectionID = staffSection.Id;
            _doctorSection = doctorSection;
            _doctorSectionID = doctorSection.Id;
            _hygieneSection = hygieneSection;
            _hygieneSectionID = hygieneSection.Id;
            _equipmentSection = equipmentSection;
            _equipmentSectionID = equipmentSection.Id;

        }

        public long GetId()
        {
            throw new NotImplementedException();
        }

        public void SetId(long id)
        {
            throw new NotImplementedException();
        }
    }
}
