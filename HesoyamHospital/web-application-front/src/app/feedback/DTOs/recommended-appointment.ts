import { TimeInterval } from './time-interval'
export class RecommendedAppointment {
    constructor(
        public Priority : string,
        public TimeInterval : TimeInterval,
        public DoctorId : number
    ) {}
}
