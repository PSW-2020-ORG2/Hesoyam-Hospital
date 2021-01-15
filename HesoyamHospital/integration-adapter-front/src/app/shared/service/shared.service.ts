import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  
  readonly _APIUrl="http://localhost:54297/gateway"

  constructor(private _http : HttpClient) { }

  getAllPatients(): Observable<any> {
    return this._http.get(this._APIUrl + '/medicineSpecificationAcquisition/getALL/patients' );
  }

  getAllMedicines(): Observable<any> {
    return this._http.get(this._APIUrl + '/medicine/all' );
  }

  getAllPharmacy(): Observable<any> {
    return this._http.get(this._APIUrl + '/registerpharmacy/all' );
  }
}
