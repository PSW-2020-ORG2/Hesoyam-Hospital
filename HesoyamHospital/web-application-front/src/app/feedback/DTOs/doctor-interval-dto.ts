import { TimeInterval } from './time-interval';

export class DoctorIntervalDto {
    constructor(
        public Id : number,
        public StartDate : Date,
        public EndDate : Date,
        public PriorityDoctor : boolean
    ) {}
}
