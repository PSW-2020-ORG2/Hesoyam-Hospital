import { TimeInterval } from 'src/app/feedback/DTOs/time-interval';

export class AppointmentDto {
    constructor(
        public appointmentId : number,
        public appointmentState : string,
        public timeInterval : TimeInterval,
        public department : string,
        public doctorName : string,
        public roomNumber : string,
        public ableToFillOutSurvey : boolean
    ) {}
}
