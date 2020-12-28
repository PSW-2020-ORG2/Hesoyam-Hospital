using Authentication.Model.UserModel;
using Authentication.Model.Util;
using System;

namespace Authentication.Model.MedicalRecordModel
{
    public class Report : Document
    {
        public string Comment { get; set; }

        public Report (long id)
        {
            Id = id;
            DateCreated = DateTime.Now;
            Type = DocumentType.REPORT;
        }

        public Report (long id, Patient patient, Doctor doctor, string comment, Diagnosis diagnosis)
        {
            Id = id;
            Patient = patient;
            Doctor = doctor;
            Comment = comment;
            Diagnosis = diagnosis;
            Type = DocumentType.REPORT;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public override bool Equals(object obj)
        {
            return obj is Report report && Id == report.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }

        public override bool MeetsCriteria(DocumentSearchCriteria criteria)
        {
            if (!base.MeetsCriteria(criteria)) return false;
            if (!Comment.ToLower().Contains(criteria.Comment.ToLower())) return false;
            return true;
        }

        public override bool MeetsAdvancedTextCriteria(FilterType filterType, TextFilter textFilter)
        {
            if (filterType == FilterType.COMMENT && MeetsCommentCriteria(textFilter)) return true;
            if ((filterType == FilterType.DOCTORS_NAME || filterType == FilterType.DIAGNOSIS_NAME) && base.MeetsAdvancedTextCriteria(filterType, textFilter)) return true;
            return false;
        }

        private bool MeetsCommentCriteria(TextFilter filter)
        {
            if (filter.Filter == TextmatchFilter.EQUAL && Comment.ToLower().Equals(filter.Text.ToLower())) return true;
            if (filter.Filter == TextmatchFilter.CONTAINS && Comment.ToLower().Contains(filter.Text.ToLower())) return true;
            if (filter.Filter == TextmatchFilter.DOES_NOT_CONTAIN && !Comment.ToLower().Contains(filter.Text.ToLower())) return true;
            return false;
        }
    }
}
