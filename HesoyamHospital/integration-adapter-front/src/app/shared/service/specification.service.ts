import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SpecificationService {

  readonly _APIUrl="http://localhost:54574/api/medicinespecificationacquisition"

  constructor(private _http : HttpClient) { }

  GetSpecification(val:any): Observable<any>{
    console.log(val);
     return this._http.get(this._APIUrl+'/specification/'+val,{responseType: 'text'});
  }
}
