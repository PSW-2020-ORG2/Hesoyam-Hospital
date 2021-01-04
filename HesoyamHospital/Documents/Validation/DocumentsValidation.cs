using Documents.Util;

namespace Documents.Validation
{
    public class DocumentsValidation
    {
        public bool IsSearchCriteriaValid(DocumentSearchCriteria criteria)
            => criteria != null &&
            criteria.DoctorName != null &&
            criteria.MedicineName != null &&
            criteria.Comment != null &&
            criteria.DiagnosisName != null &&
            criteria.TimeInterval != null &&
            criteria.TimeInterval.IsInOrder() &&
            criteria.TimeInterval.IsInThePast();

        public bool IsAdvancedSearchCriteriaValid(AdvancedDocumentSearchCriteria criteria)
            => criteria != null &&
            criteria.LogicalOperators != null &&
            criteria.TextFilters != null &&
            criteria.TimeIntervalFilters != null &&
            criteria.FilterTypes != null &&
            criteria.IsConsistent();
    }
}
