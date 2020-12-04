import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegisteredPharmacy } from '../model/registered-pharmacy.model';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {


  readonly _APIUrl="http://localhost:54574/api"

  constructor(private _http : HttpClient) { }

  getPharmacy(val:any){
    return this._http.post(`${this._APIUrl}/registerpharmacy`,val);
  }
}
