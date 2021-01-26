import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UrgentMedicineProcurementRequest } from '../model/urgent-medicine-procurement-request.model'
import { RegisteredPharmacy } from '../model/registered-pharmacy.model';


@Injectable({
  providedIn: 'root'
})
export class UrgentMedicineProcurementService {

  readonly _APIUrl="http://localhost:54297/gateway"

  constructor(private _http : HttpClient) { }

  getAllPharmacies(id:number,pharmacies:RegisteredPharmacy[]):Promise<any>{
    return this._http.post(this._APIUrl+'/getPharmacies/'+id,pharmacies).toPromise();
  }

  getAllRequests(): Observable<any> {
    return this._http.get(this._APIUrl+'/urgentmedicineprocurement/allunconcluded');
  }
  
  MakeRequest(request:UrgentMedicineProcurementRequest): Observable<any> {
    return this._http.post(this._APIUrl + '/createRequest',request);
  }

  OrderMedicine(pharmacy:RegisteredPharmacy,requestId:number):Observable<any>{
    return this._http.put(this._APIUrl+'/'+requestId,pharmacy);
  }
}
