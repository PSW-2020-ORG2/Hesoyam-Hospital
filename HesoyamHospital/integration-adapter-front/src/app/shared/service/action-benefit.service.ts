import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ActionBenefit } from '../model/action-benefit.model';


@Injectable({
  providedIn: 'root'
})
export class ActionBenefitService {
  readonly _APIUrl="http://localhost:54297/gateway"

  constructor(private _http : HttpClient) { }
  
  getAllActionBenefit(): Observable<any> {
    return this._http.get(this._APIUrl + '/unapproved' )
  }

  Approved(val:number): Observable<any>{
    console.log(val);
     return this._http.put(this._APIUrl+'/approve/'+val,{id:val});
  }
  
  /*Delete(val:any): Observable<any>{
    return this._http.delete(this._APIUrl+'/delete'+val);
  }*/
}
