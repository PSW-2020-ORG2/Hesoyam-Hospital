import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Therapy } from '../model/therapy.model';

@Injectable({
  providedIn: 'root'
})
export class TherapyService {

  readonly _APIUrl="http://localhost:54574/api/medicinespecificationacquisition"

  constructor(private _http : HttpClient) { }

  PutTherapy(therapy:Therapy): Observable<any> {
    return this._http.put(this._APIUrl + '/prescription/markoFARM',therapy)
  }

}
