import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TenderService {
  readonly _APIUrl="http://localhost:54574/api/tender";


  constructor(private _http:HttpClient) { }

  GetAllUnconcludedTenders():Observable<any>{
    return this._http.get(this._APIUrl+'/active');
  }

}
