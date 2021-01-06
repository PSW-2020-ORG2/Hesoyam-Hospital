﻿namespace Feedbacks.Model
{
    public class Survey
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public virtual Section StaffSection { get; set; }
        public virtual Section DoctorSection { get; set; }
        public virtual Section HygieneSection { get; set; }
        public virtual Section EquipmentSection { get; set; }

        public Survey()
        {
        }

        public Survey(long id) {

            Id = id;

        }

        public Survey(long id, long doctorId, Section staffSection, Section doctorSection, Section hygieneSection, Section equipmentSection)
        {

            Id = id;
            DoctorId = doctorId;
            StaffSection = staffSection;
            DoctorSection = doctorSection;
            HygieneSection = hygieneSection;
            EquipmentSection = equipmentSection;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}
