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
  pharmacyName:string;
  
  Request(requestId:number){
    this.urgentMedicineProcurementService.getAllPharmacies(requestId)
    .subscribe(
      (data => {
        this.pharmacies=data
      })
    );
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

  Order(id:number){
    this.urgentMedicineProcurementService.OrderMedicine(this.pharmacyName,this.GetSelectedRequest(id)).subscribe(
      message=>alert("Medicine ordered")
    )
  }
}
