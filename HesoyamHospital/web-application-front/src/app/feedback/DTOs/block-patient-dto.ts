export class BlockPatientDto {
    constructor(
        public username : string,
        public cancelCount : number,
        public fullName : string,
        public blocked : boolean
    ) {}
}
