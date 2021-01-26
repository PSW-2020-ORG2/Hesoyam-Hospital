import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Tender } from '../model/tender.model';

@Injectable({
  providedIn: 'root'
})
export class TenderService {
  readonly _APIUrl="http://localhost:54297/gateway";


  constructor(private _http:HttpClient) { }

  GetAllActiveTenders():Observable<any>{
    return this._http.get(this._APIUrl+'/active');
  }

  GetAllUnconcludedTenders():Observable<any>{
    return this._http.get(this._APIUrl+'/unconcluded');
  }

  ChooseWinningOffer(tenderId:number,winnerOfferId:number,allEmails:string[]):Observable<any>
  {
    return this._http.put(this._APIUrl+'/concludeTender/'+tenderId+'/'+winnerOfferId,allEmails);
  }

  AddTender(tender:Tender):Observable<any>{
    return this._http.post(this._APIUrl+'/createTender',tender);
  }
}
