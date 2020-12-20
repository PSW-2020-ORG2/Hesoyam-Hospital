import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MedicineAvailability } from '../model/medicine-availability.model';


@Injectable({
  providedIn: 'root'
})
export class MedicineAvailabilityService {
  readonly _APIUrl="http://localhost:54574/api/medicine";
  
  constructor(private _http : HttpClient) { }

  getPharmacy(pharmacyName:string,medicineName:string):Observable<MedicineAvailability>{
    return this._http.get<MedicineAvailability>(this._APIUrl+'/'+pharmacyName+'/'+medicineName);
  }
}

