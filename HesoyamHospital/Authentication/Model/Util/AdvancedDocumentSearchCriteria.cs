using System.Collections.Generic;

namespace Authentication.Model.Util
{
    public class AdvancedDocumentSearchCriteria
    {
        public bool ShouldSearchPrescriptions { get; set; }
        public bool ShouldSearchReports { get; set; }
        public List<FilterType> FilterTypes { get; set; }
        public List<LogicalOperator> LogicalOperators { get; set; }
        public List<TextFilter> TextFilters { get; set; }
        public List<TimeIntervalFilter> TimeIntervalFilters { get; set; }

        public AdvancedDocumentSearchCriteria()
        {
        }

        public AdvancedDocumentSearchCriteria(bool shouldSearchPrescriptions, bool shouldSearchReports, List<FilterType> filterTypes, List<LogicalOperator> logicalOperators, List<TextFilter> textFilters, List<TimeIntervalFilter> timeIntervalFilters)
        {
            ShouldSearchPrescriptions = shouldSearchPrescriptions;
            ShouldSearchReports = shouldSearchReports;
            FilterTypes = filterTypes;
            LogicalOperators = logicalOperators;
            TextFilters = textFilters;
            TimeIntervalFilters = timeIntervalFilters;
        }

        public bool IsConsistent()
            => FilterTypes.Count == TextFilters.Count + TimeIntervalFilters.Count && (LogicalOperators.Count + 1 == TextFilters.Count + TimeIntervalFilters.Count || (LogicalOperators.Count == 0 && FilterTypes.Count == 0));

        public bool HasElements()
            => FilterTypes.Count > 0;

        public void SetInitialState()
        {
            if (IsConsistent()) LogicalOperators.Insert(0, LogicalOperator.AND);
        }
    }
}
