import { Component, OnInit } from '@angular/core';
import { RegisteredPharmacy } from '../shared/model/registered-pharmacy.model';
import { UrgentMedicineProcurementRequest } from '../shared/model/urgent-medicine-procurement-request.model'
import { UrgentMedicineProcurementService } from '../shared/service/urgent-medicine-procurement.service'


@Component({
  selector: 'app-urgent-medicine-procurement-list',
  templateUrl: './urgent-medicine-procurement-list.component.html',
  styleUrls: ['./urgent-medicine-procurement-list.component.scss']
})
export class UrgentMedicineProcurementListComponent implements OnInit {

  constructor(private urgentMedicineProcurementService:UrgentMedicineProcurementService) { }

  ngOnInit(): void {
    this.urgentMedicineProcurementService.getAllRequests().subscribe(
      data=>
      this.requests=data
    )
  }
  
  requests:UrgentMedicineProcurementRequest[]=[];
  pharmacies:RegisteredPharmacy[]=[];
  selectedRequest:UrgentMedicineProcurementRequest=new UrgentMedicineProcurementRequest;
  pharmacyName:string;
  
  Request(requestId:number){
    this.selectedRequest=this.GetSelectedRequest(requestId)
    this.urgentMedicineProcurementService.getAllPharmacies(this.selectedRequest)
    .subscribe(
      (data => {
        this.pharmacies=data
      })
    );


  }
  GetSelectedRequest(id:number):UrgentMedicineProcurementRequest{
    this.requests.forEach(
      r=>{
        if(r.Id==id)
        {
          return r;
          }
      }
    )
    return null;
  }

  Order(){
    this.urgentMedicineProcurementService.OrderMedicine(this.pharmacyName,this.selectedRequest).subscribe(
      message=>alert("Medicine ordered")
    )
  }
}
