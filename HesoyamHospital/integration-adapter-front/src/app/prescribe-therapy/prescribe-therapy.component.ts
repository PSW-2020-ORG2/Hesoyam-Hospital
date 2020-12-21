import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormGroup , Validators} from '@angular/forms'
import { Medicine } from '../shared/model/medicine.model';
import { Therapy } from '../shared/model/therapy.model';
import {TherapyService} from 'src/app/shared/service/therapy.service'

@Component({
  selector: 'app-prescribe-therapy',
  templateUrl: './prescribe-therapy.component.html',
  styleUrls: ['./prescribe-therapy.component.scss']
})
export class PrescribeTherapyComponent implements OnInit {

  therapyForm :FormGroup;
  minDate : Date ;
  medicines: Medicine[]=[{
    Id:1,
    Name:"Paracetamol"
    },{
    Id:2,
    Name:"Andol"
    },{
    Id:3,
    Name:"Brufen"
    }];
  medID:number;
  
  selectedMed:string[]=[];
  patientID:number;

  patients:number[]=[]; 
  therapy:Therapy=new Therapy;
  patientId:number;

  constructor(private fb: FormBuilder,private therapyService:TherapyService) {
    this.minDate=new Date();
   }

  ngOnInit(): void {
    this.therapyForm=this.fb.group({
      Start:['',[Validators.required]],
      End:['',[Validators.required]]
    });
    this.patients.push(1);
  }

  SendTherapy(){
    this.therapy.StartTime=this.therapyForm.get('Start').value;
    this.therapy.EndTime=this.therapyForm.get('End').value;
    this.therapy.DateCreated =new Date();
    this.therapy.PatientID=1;
    this.therapy.DoctorID=2;
    this.therapy.Comment="";
    console.log(this.therapy);
    this.therapyService.PutTherapy(this.therapy).subscribe(
      red=>alert("Therapy sent")
    )

  }


  AddMedicine(){
    this.selectedMed.push(this.medicines[this.medID-1].Name);
    this.therapy.MedicineIDs.push(this.medicines[this.medID-1].Id);
  }

}
