import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormGroup , Validators} from '@angular/forms'
import { Medicine } from '../shared/model/medicine.model';
import { MedicineAvailabilityService } from 'src/app/shared/service/medicine-availability.service';
import { RegisteredPharmacy } from '../shared/model/registered-pharmacy.model';
import { MedicineAvailability } from '../shared/model/medicine-availability.model';
import { SharedService } from '../shared/service/shared.service';

@Component({
  selector: 'app-medicine-availability',
  templateUrl: './medicine-availability.component.html',
  styleUrls: ['./medicine-availability.component.scss']
})
export class MedicineAvailabilityComponent implements OnInit {

  constructor(private fb: FormBuilder,private sharedService:SharedService,private medicineAvailabilityService:MedicineAvailabilityService) { }

  availabilityForm:FormGroup;
  medicines: Medicine[]=[];
  medID:number;
  
  pharmacies:RegisteredPharmacy[]=[];
  selectedPharmacy:RegisteredPharmacy;

  pharmacyName:string;
  
  available: MedicineAvailability=new MedicineAvailability();
  availableAdresses:string="";
  ngOnInit(): void {
    this.FillPharmacy();
    this.availabilityForm=this.fb.group({});
    this.FillMedicines();
    console.log(this.medicines);
  }

  async FillPharmacy(){
    await this.sharedService.getAllPharmacy().then(data => {
      this.pharmacies = data
    })
  }
  FillMedicines(){
    this.sharedService.getAllMedicines().subscribe(
      data=>this.medicines=data
    );
  }

  CheckMedicine(){
    this.GetSelectedPharmacy()
    this.availableAdresses = '';
    this.medicineAvailabilityService.getPharmacy(this.selectedPharmacy,this.medicines[this.medID-1].Name)
    .subscribe(data => {
      this.available = data;
      if(this.available.Addresses != null){
        this.available.Addresses.forEach(
          a=> this.availableAdresses+=a)
      } else {
        this.availableAdresses = "Medicine unavailable!";
      }
    }, err => {
      alert(err.error);
    } 
    )
  }
  
GetSelectedPharmacy(){
    this.pharmacies.forEach(p=>
     {
       if(p.PharmacyName==this.pharmacyName)
        {
          this.selectedPharmacy=p;
        }
     })
  
  }
}

