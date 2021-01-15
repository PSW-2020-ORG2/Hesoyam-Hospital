import { TherapyDTO } from "./therapy-dto";

export class PrescriptionDTO {
    constructor(
        public dateTimeCreated : Date,
        public doctorFullName : string,
        public doctorSpecialisation : string,
        public diagnosis : string,
        public therapies : TherapyDTO[]
    ) {}
}
