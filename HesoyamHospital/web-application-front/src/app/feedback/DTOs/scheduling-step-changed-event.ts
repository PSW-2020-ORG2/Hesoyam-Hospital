export class SchedulingStepChangedEvent {
    constructor(
        public patientUsername : string,
        public stepType : number,
        public currentStep : number
    ) {}
}
