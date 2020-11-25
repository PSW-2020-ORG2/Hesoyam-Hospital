class TimeInterval {
    constructor(
        public StartTime : Date,
        public EndTime : Date
    ) {}
}

export class SearchCriteriaDTO {
    constructor(
        public ShouldSearchReports : boolean,
        public ShouldSearchPrescriptions : boolean,
        public TimeInterval : TimeInterval,
        public DoctorName : string,
        public DiagnosisName : string,
        public MedicineName : string,
        public Comment : string
    ) {}
}
