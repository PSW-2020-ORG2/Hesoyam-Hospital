import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


export interface Doctor {
  userName: string;
  fullName: string;
}

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  private _urlgetdoctors:string = "http://localhost:52166/api/appointment/getDoctorsByType/";
  private _urlpost:string = "http://localhost:52166/api/document/simple-search/500";
  private _urlpostadvanced:string = "http://localhost:52166/api/document/advanced-search/500";

  constructor( private _http : HttpClient) { }

  getAll() : Observable<Doctor[]> {
    return this._http.get<Doctor[]>(this._urlgetdoctors);
  }

}
