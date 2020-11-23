export class DocumentSearchCriteria {
    constructor(
        public ShouldSearchPrescriptions : boolean,
        public ShouldSearchReports : boolean,
        public TimeInterval : Date,
        public DoctorName : string,
        public DiagnosisName : string,
        public MedicineName : string,
        public Comment : string
    ) {}
}
