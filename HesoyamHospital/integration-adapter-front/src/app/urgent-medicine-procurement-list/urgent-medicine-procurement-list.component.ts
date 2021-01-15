import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UrgentRequestDialogComponent } from '../dialog/urgent-request-dialog/urgent-request-dialog.component';
import { RegisteredPharmacy } from '../shared/model/registered-pharmacy.model';
import { UrgentMedicineProcurementRequest } from '../shared/model/urgent-medicine-procurement-request.model'
import { SharedService } from '../shared/service/shared.service';
import { UrgentMedicineProcurementService } from '../shared/service/urgent-medicine-procurement.service'


@Component({
  selector: 'app-urgent-medicine-procurement-list',
  templateUrl: './urgent-medicine-procurement-list.component.html',
  styleUrls: ['./urgent-medicine-procurement-list.component.scss']
})
export class UrgentMedicineProcurementListComponent implements OnInit {

  constructor(public dialog: MatDialog,private sharedService:SharedService,private urgentMedicineProcurementService:UrgentMedicineProcurementService) { }

  ngOnInit(): void {
    this.urgentMedicineProcurementService.getAllRequests().subscribe(
      data=>
      this.requests=data
    )
  }
  
  openDialog(): void {
    const dialogRef = this.dialog.open(UrgentRequestDialogComponent, {
      data:{
        pharmacies:this.pharmacies,
        selectedRequest:this.selectedRequest
      }
    });

    dialogRef.afterClosed().subscribe(result => {
     this.ngOnInit()
    });
  }

  requests:UrgentMedicineProcurementRequest[]=[];
  selectedRequest:UrgentMedicineProcurementRequest=new UrgentMedicineProcurementRequest;
  pharmacies:RegisteredPharmacy[]=[];
 
  async Request(requestId:number){
    await this.urgentMedicineProcurementService.getAllPharmacies(requestId,this.GetAllPharmacies())
    .then(
      (data => {
        this.pharmacies=data
      })
    );
    this.selectedRequest=this.GetSelectedRequest(requestId);
    this.openDialog();
  }
  GetAllPharmacies():RegisteredPharmacy[]{
    var p;
    this.sharedService.getAllPharmacy().subscribe(
      data=>p=data
    )
    return p;
  }
  

  GetSelectedRequest(id:number):UrgentMedicineProcurementRequest{
    let retVal = null
    this.requests.forEach(
      r=>{
        if(r.Id==id)
        {
          retVal = r;
        }
      }
    )
    return retVal;
  }

 
}
