import { TherapyDTO } from "./therapy-dto";

export class PrescriptionDTO {
    constructor(
        public dateTimeCreated : string,
        public doctorFullName : string,
        public doctorSpecialisation : string,
        public diagnosis : string,
        public therapies : TherapyDTO[]
    ) {}
}
