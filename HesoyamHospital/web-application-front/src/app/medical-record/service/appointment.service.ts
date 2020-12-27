import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppointmentDto } from '../DTOs/appointment-dto';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  private _urlgetall:string = "http://localhost:57874/gateway/appointment/500";
  private _urlcancel:string = "http://localhost:57874/gateway/appointment/cancel";

  constructor( private _http : HttpClient) { }

  getAll() : Observable<AppointmentDto[]> {
    return this._http.get<AppointmentDto[]>(this._urlgetall);
  }

  cancel(appointmentId : number) {
    return this._http.put(this._urlcancel, appointmentId);
  }

}
