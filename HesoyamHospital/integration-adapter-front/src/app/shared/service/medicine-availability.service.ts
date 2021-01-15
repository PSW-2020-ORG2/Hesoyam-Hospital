import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MedicineAvailability } from '../model/medicine-availability.model';
import { RegisteredPharmacy } from '../model/registered-pharmacy.model';


@Injectable({
  providedIn: 'root'
})
export class MedicineAvailabilityService {
  readonly _APIUrl="http://localhost:54297/gateway";
  
  constructor(private _http : HttpClient) { }

  getPharmacy(pharmacy:RegisteredPharmacy,medicineName:string):Observable<any>{
    return this._http.post<any>(this._APIUrl+'/getAvailability/'+medicineName,pharmacy);
  }
}

