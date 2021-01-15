import { Component, Inject, OnInit } from '@angular/core';
import { inject } from '@angular/core/testing';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { RegisteredPharmacy } from 'src/app/shared/model/registered-pharmacy.model';
import { UrgentMedicineProcurementRequest } from 'src/app/shared/model/urgent-medicine-procurement-request.model';
import { UrgentMedicineProcurementService } from 'src/app/shared/service/urgent-medicine-procurement.service';

@Component({
  selector: 'app-urgent-request-dialog',
  templateUrl: './urgent-request-dialog.component.html',
  styleUrls: ['./urgent-request-dialog.component.scss']
})
export class UrgentRequestDialogComponent implements OnInit {

  constructor(public dialogRef:MatDialogRef<UrgentRequestDialogComponent>,
    @Inject( MAT_DIALOG_DATA) public data:{
      pharmacies:RegisteredPharmacy[],
      selectedRequest:UrgentMedicineProcurementRequest

    } ,private urgentMedicineProcurementService:UrgentMedicineProcurementService) { }

  pharmacyName:string;
  ngOnInit(): void {
    console.log(this.data.pharmacies);
    
  }
  
GetPharmacy():any{
  this.data.pharmacies.forEach(p=>
   {
     if(p.PharmacyName==this.pharmacyName)
      {
        console.log(p.PharmacyName);
        return p
      }
   })

}
  
  Order(){
    console.log(this.pharmacyName);
    console.log(this.data.selectedRequest);
    this.urgentMedicineProcurementService.OrderMedicine(this.GetPharmacy(),this.data.selectedRequest.Id).subscribe(
      m=>{
      this.dialogRef.close()
    }
    )
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
}
