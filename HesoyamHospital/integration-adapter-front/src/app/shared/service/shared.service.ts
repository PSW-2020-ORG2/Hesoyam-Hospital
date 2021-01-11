import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  
  readonly _APIUrl="http://localhost:54574/api"

  constructor(private _http : HttpClient) { }

  getAllPatients(): Observable<any> {
    return this._http.get(this._APIUrl + '/medicineSpecificationAcquisition/getALL/patients' )
  }

  
  getAllMedicines(): Observable<any> {
    return this._http.get(this._APIUrl + '/medicineSpecificationAcquisition/getALL/medicines' )
  }

  getAllPharmacy(): Observable<any> {
    return this._http.get(this._APIUrl + 'registerpharmacy/all' )
  }
}
