import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormControl,FormGroup , Validators} from '@angular/forms'
import { Medicine } from '../shared/model/medicine.model';
import { UrgentMedicineProcurementRequest } from '../shared/model/urgent-medicine-procurement-request.model'
import { UrgentMedicineProcurementService } from '../shared/service/urgent-medicine-procurement.service'
import { SharedService } from '../shared/service/shared.service'
@Component({
  selector: 'app-urgent-medicine-procurement-request',
  templateUrl: './urgent-medicine-procurement-request.component.html',
  styleUrls: ['./urgent-medicine-procurement-request.component.scss']
})
export class UrgentMedicineProcurementRequestComponent implements OnInit {

  constructor(private fb: FormBuilder,private sharedService:SharedService,private urgentMedicineProcurementRequestService:UrgentMedicineProcurementService) { }

  medicineRequestForm:FormGroup;
  medName:string;
  medicines:Medicine[]=[]
  request:UrgentMedicineProcurementRequest= new UrgentMedicineProcurementRequest;

  ngOnInit(): void {
    this.medicineRequestForm=this.fb.group({
    quantity:['', [Validators.pattern("^[0-9]*$"),Validators.required]],
    selectedMedicine:new FormControl()
  })
    this.FillMedication();
  }

  FillMedication(){
    this.sharedService.getAllMedicines().subscribe(data => {
      this.medicines = data
    })
  }

  MakeRequest(){
    this.request.Medicine=this.medName;
    this.request.Quantity=this.medicineRequestForm.get('quantity').value;
    this.urgentMedicineProcurementRequestService.MakeRequest(this.request).subscribe(
      red=>alert("Request sent")
    )
  }
}
