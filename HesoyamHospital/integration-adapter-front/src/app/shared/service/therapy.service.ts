import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Therapy } from '../model/therapy.model';
import { RegisteredPharmacy } from '../model/registered-pharmacy.model';

@Injectable({
  providedIn: 'root'
})
export class TherapyService {

  readonly _APIUrl="http://localhost:54297/gateway"

  constructor(private _http : HttpClient) { }

  AddTherapy(therapy:Therapy): Observable<any> {
    return this._http.post(this._APIUrl + '/addtherapy',therapy);
  }

  SendPrescription(pharmacy:RegisteredPharmacy,therapyId:number,patientJmbg:string):Observable<any>
  {
    return this._http.post(this._APIUrl+'/sendPrescription/'+therapyId+'/'+patientJmbg,pharmacy);
  }
  

}
