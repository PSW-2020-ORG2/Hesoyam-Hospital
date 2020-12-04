import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormGroup , Validators} from '@angular/forms'
import {RegistrationService} from 'src/app/shared/service/registration.service'
import { RegisteredPharmacy } from '../shared/model/registered-pharmacy.model';

@Component({
  selector: 'app-pharmacy-registration',
  templateUrl: './pharmacy-registration.component.html',
  styleUrls: ['./pharmacy-registration.component.scss']
})
export class PharmacyRegistrationComponent implements OnInit {

  myForm :FormGroup;

  constructor(private fb: FormBuilder,private service:RegistrationService) { }
  Pharmacy:RegisteredPharmacy=new RegisteredPharmacy();
  ngOnInit(): void {
    this.myForm=this.fb.group({
      pharmacyName :['',[Validators.required]],
      apiKey:['',[Validators.required]],
      endpoint:['',[Validators.required]]
    })

  }

  AddPharmacy(){
    this.Pharmacy.ApiKey=this.myForm.get('apiKey').value;
    this.Pharmacy.PharmacyName=this.myForm.get('pharmacyName').value;
    this.Pharmacy.Endpoint=this.myForm.get('endpoint').value;
    this.service.getPharmacy(this.Pharmacy).subscribe(res=>{
      alert(res.toString());
        });
  }

}
