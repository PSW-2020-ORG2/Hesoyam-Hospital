export class AppointmentDTO {
    constructor(
        public PatientId : number,
        public DateAndTime : Date,
        public DoctorId : number
    ) {}
}