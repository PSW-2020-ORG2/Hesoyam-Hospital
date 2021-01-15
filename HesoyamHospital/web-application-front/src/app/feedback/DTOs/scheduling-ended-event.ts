export class SchedulingEndedEvent {
    constructor(
        public patientUsername : string,
        public outcome : number
    ) {}
}
