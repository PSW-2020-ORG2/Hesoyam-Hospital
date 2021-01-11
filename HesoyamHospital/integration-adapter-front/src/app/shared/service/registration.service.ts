import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {


  readonly _APIUrl="http://localhost:54574/api/registerpharmacy"

  constructor(private _http : HttpClient) { }

  getPharmacy(val:any){
    return this._http.post(this._APIUrl,val);
  }
}
