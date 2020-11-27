using System.Collections.Generic;

namespace Backend.Model.PatientModel
{
    public class AdvancedDocumentSearchCriteria
    {
        public DocumentType DocumentType { get; set; }
        public List<FilterType> FilterTypes { get; set; }
        public List <LogicalOperator> LogicalOperators { get; set; }
        public List<TextFilter> TextFilters { get; set; }
        public List<TimeIntervalFilter> TimeIntervalFilters { get; set; }

        public AdvancedDocumentSearchCriteria(DocumentType documentType, List<FilterType> filterTypes, List<LogicalOperator> logicalOperators, List<TextFilter> textFilters, List<TimeIntervalFilter> timeIntervalFilters)
        {
            DocumentType = documentType;
            FilterTypes = filterTypes;
            LogicalOperators = logicalOperators;
            TextFilters = textFilters;
            TimeIntervalFilters = timeIntervalFilters;
        }
    }
}
