﻿using System.Collections.Generic;

namespace Backend.Model.PatientModel
{
    public class AdvancedDocumentSearchCriteria
    {
        public bool ShouldSearchPrescriptions { get; set; }
        public bool ShouldSearchReports { get; set; }
        public List<FilterType> FilterTypes { get; set; }
        public List <LogicalOperator> LogicalOperators { get; set; }
        public List<TextFilter> TextFilters { get; set; }
        public List<TimeIntervalFilter> TimeIntervalFilters { get; set; }

        public AdvancedDocumentSearchCriteria(bool shouldSearchPrescriptions, bool shouldSearchReports, List<FilterType> filterTypes, List<LogicalOperator> logicalOperators, List<TextFilter> textFilters, List<TimeIntervalFilter> timeIntervalFilters)
        {
            ShouldSearchPrescriptions = shouldSearchPrescriptions;
            ShouldSearchReports = shouldSearchReports;
            FilterTypes = filterTypes;
            LogicalOperators = logicalOperators;
            TextFilters = textFilters;
            TimeIntervalFilters = timeIntervalFilters;
        }
    }
}
