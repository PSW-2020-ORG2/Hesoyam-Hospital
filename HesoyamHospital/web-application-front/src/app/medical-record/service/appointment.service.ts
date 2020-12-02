import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppointmentDto } from '../DTOs/appointment-dto';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  private _urlgetall:string = "http://localhost:52166/api/appointment/500";

  constructor( private _http : HttpClient) { }

  getAll() : Observable<AppointmentDto[]> {
    return this._http.get<AppointmentDto[]>(this._urlgetall);
  }

}
