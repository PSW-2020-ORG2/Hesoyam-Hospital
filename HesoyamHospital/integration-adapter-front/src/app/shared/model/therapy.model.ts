export class Therapy {
    Id:number;
    StartTime:Date ;
    EndTime :Date
    DateCreated:Date
    PatientID:number;
    DoctorID:number;
    Comment:string;
    MedicineIDs:number[]=[];
}

