import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormGroup , Validators} from '@angular/forms'
import { Medicine } from '../shared/model/medicine.model';
import { Therapy } from '../shared/model/therapy.model';
import {TherapyService} from 'src/app/shared/service/therapy.service'
import { RegisteredPharmacy } from '../shared/model/registered-pharmacy.model';
import { SharedService } from '../shared/service/shared.service';
import { Patient } from '../shared/model/patient.model';

@Component({
  selector: 'app-prescribe-therapy',
  templateUrl: './prescribe-therapy.component.html',
  styleUrls: ['./prescribe-therapy.component.scss']
})
export class PrescribeTherapyComponent implements OnInit {

  therapyForm :FormGroup;
  minDate : Date ;
  medicines: Medicine[]=[];
  medID:number;
  
  selectedMed:string[]=[];

  patients:Patient[]=[]; 
  therapy:Therapy=new Therapy;
  patientJMBG:string;
  pharmacyName:string;
  pharmacy:RegisteredPharmacy=new RegisteredPharmacy;
  pharmacies:RegisteredPharmacy[]=[];
  patient:Patient=new Patient;
  selectedMedicine: Medicine=new Medicine;

  constructor(private fb: FormBuilder,private sharedService:SharedService,private therapyService:TherapyService) {
    this.minDate=new Date();
   }

  ngOnInit(): void {
    this.therapyForm=this.fb.group({
      Start:['',[Validators.required]],
      End:['',[Validators.required]],
      Comment:['']
    });
    
    this.FillPatients();
    console.log(this.patients);
    this.FillPharmacy();
    this.FillMedicines();  
  }

  SendTherapy(){
    this.GetSelectedPharmacy();
    this.GetSelectedPatient();
    this.therapy.StartTime=this.therapyForm.get('Start').value;
    this.therapy.EndTime=this.therapyForm.get('End').value;
    this.therapy.DateCreated =new Date();
    
    this.therapy.PatientID=this.patient.patientId;
    this.therapy.DoctorID=1;
    this.therapy.Comment=this.therapyForm.get('Comment').value;
    console.log(this.therapy);
    this.therapyService.AddTherapy(this.therapy).subscribe(
      id=>{
          this.therapy.Id=id;
          this.therapyService.SendPrescription(this.pharmacy,this.therapy.Id,this.patientJMBG).subscribe(
              data=>alert("Therapy sent"),
              err=>alert(err.error)
          )
        },err=>alert(err.error)
    )
  }

  FillMedicines(){
    this.sharedService.getAllMedicines().subscribe(
      data=>this.medicines=data,
      err=>alert(err.error)
    );
  }

  async FillPatients(){
    await this.sharedService.getAllPatients().then(
      data=>this.patients=data
    );
  }

  async FillPharmacy(){
    await this.sharedService.getAllPharmacy().then(data => {
      this.pharmacies = data
    })
  }

  AddMedicine(){
    this.selectedMed.push(this.medicines[this.medID-1].Name);
    this.therapy.MedicineIDs.push(this.medID);
  }

  GetSelectedPatient(){
    this.patients.forEach(p=>
     {
       if(p.jmbg==this.patientJMBG)
        {
          this.patient=p;
        }
     })
  
  }


  GetSelectedPharmacy(){
    this.pharmacies.forEach(p=>
     {
       if(p.PharmacyName==this.pharmacyName)
        {
          this.pharmacy=p;
        }
     })
  
  }

}
