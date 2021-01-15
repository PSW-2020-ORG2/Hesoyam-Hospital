export class ReportDTO {
    constructor(
        public dateTimeCreated : string,
        public doctorFullName : string,
        public doctorSpecialisation : string,
        public diagnosis : string,
        public comment : string
    ) {}
}
