import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UrgentMedicineProcurementRequest } from '../model/urgent-medicine-procurement-request.model'
import { RegisteredPharmacy } from '../model/registered-pharmacy.model';


@Injectable({
  providedIn: 'root'
})
export class UrgentMedicineProcurementService {

  readonly _APIUrl="http://localhost:54574/api/urgentMedicineProcurement"

  constructor(private _http : HttpClient) { }

  getAllPharmacies(id:number):Observable<any>{
    return this._http.get(this._APIUrl+'/getPharmacies/'+id);
  }

  getAllRequests(): Observable<any> {
    return this._http.get(this._APIUrl);
  }
  
  MakeRequest(request:UrgentMedicineProcurementRequest): Observable<any> {
    return this._http.post(this._APIUrl + '/createRequest',request);
  }

  OrderMedicine(pharmacyName:string,request:UrgentMedicineProcurementRequest):Observable<any>{
    return this._http.put(this._APIUrl+'/'+pharmacyName,request);
  }
}
