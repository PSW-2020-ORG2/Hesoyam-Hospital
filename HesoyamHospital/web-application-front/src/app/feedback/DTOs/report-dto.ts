export class ReportDTO {
    constructor(
        public dateTimeCreated : Date,
        public doctorFullName : string,
        public doctorSpecialisation : string,
        public diagnosis : string,
        public comment : string
    ) {}
}
