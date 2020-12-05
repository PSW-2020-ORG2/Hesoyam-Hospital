export class PriorityIntervalDTO {
    constructor(
        public startTime : Date,
        public endTime : Date,
        public startTimeText : string,
        public dateText : string,
        public doctorId : number,
        public fullName : string
    ) {}
}
