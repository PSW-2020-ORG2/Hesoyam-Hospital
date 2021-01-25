import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  
  readonly _APIUrl="http://localhost:54297/gateway"

  constructor(private _http : HttpClient) { }

  getAllPatients(): Promise<any> {
    return this._http.get('http://localhost:57746/api/patient/getAllPatients').toPromise();
  }

  getAllMedicines(): Observable<any> {
    return this._http.get(this._APIUrl + '/medicine/all' );
  }

  getAllPharmacy(): Promise<any> {
    return this._http.get(this._APIUrl + '/registerpharmacy/all' ).toPromise();
  }
}
