import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TenderOffer } from '../model/tender-offer.model';


@Injectable({
  providedIn: 'root'
})
export class TenderOfferService {
  readonly _APIUrl="http://localhost:54574/api/tenderoffer";
  constructor(private _http:HttpClient) { }

  PostOffer(offer:TenderOffer):Observable<any>
  {
    return this._http.post(this._APIUrl+'/createoffer',offer);
  }
}
