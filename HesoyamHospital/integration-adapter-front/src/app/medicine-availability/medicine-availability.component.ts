import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormGroup , Validators} from '@angular/forms'
import { Medicine } from '../shared/model/medicine.model';
import { MedicineAvailabilityService } from 'src/app/shared/service/medicine-availability.service';
import {RegistrationService} from 'src/app/shared/service/registration.service'
import { RegisteredPharmacy } from '../shared/model/registered-pharmacy.model';
import { MedicineAvailability } from '../shared/model/medicine-availability.model';

@Component({
  selector: 'app-medicine-availability',
  templateUrl: './medicine-availability.component.html',
  styleUrls: ['./medicine-availability.component.scss']
})
export class MedicineAvailabilityComponent implements OnInit {

  constructor(private fb: FormBuilder,private pharmacyRegistrationService:RegistrationService,private medicineAvailabilityService:MedicineAvailabilityService) { }

  availabilityForm:FormGroup;
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
  
  pharmacies:RegisteredPharmacy[]=[];

  pyrmacyName:number;
  
  available: MedicineAvailability=new MedicineAvailability();
  availableAdresses:string="";
  ngOnInit(): void {
    this.FillPharmacy();
	this.availabilityForm=this.fb.group({})
  }

  FillPharmacy(){
    this.pharmacyRegistrationService.getAllPharmacy().subscribe(data => {
      this.pharmacies = data
    })
  }

  CheckMedicine(){
    this.medicineAvailabilityService.getPharmacy(this.pharmacies[this.pyrmacyName-1].PharmacyName,this.medicines[this.medID-1].Name)
    .subscribe(data => {
      this.available = data;
      this.available.Addresses.forEach(
        a=>this.availableAdresses+=a+"\n" 
      )
      
    })
    this.availableAdresses = ""
  }




}
