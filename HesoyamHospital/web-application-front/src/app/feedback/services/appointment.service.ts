import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DoctorDto } from '../../medical-record/DTOs/doctor-dto';
import { DoctorDateDTO } from '../patient/standard-appointment/DTOs/DoctorDateDTO';
import { TimeInterval } from '../DTOs/time-interval';
import { IntervalDTO } from '../patient/standard-appointment/DTOs/IntervalDTO';
import { AppointmentDTO } from '../patient/standard-appointment/DTOs/AppointmentDTO';


export interface Doctor {
  userName: string;
  fullName: string;
}

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  private _urlgetdoctors:string = "http://localhost:52166/api/appointmentscheduling/getDoctorsByType/";
  private _urlgettimes:string = "http://localhost:52166/api/appointmentscheduling/getTimesForDoctor/";
  private _urlsave:string = "http://localhost:52166/api/appointmentscheduling/saveAppointment";
  private _urlgettimesselecteddoctor:string = "http://localhost:52166/api/appointmentscheduling/getTimesForSelectedDoctor/500";
  private _urlsaveselecteddoctor:string = "http://localhost:52166/api/appointmentscheduling/saveSelectedDoctorAppointment";

  constructor( private _http : HttpClient) { }

  getAll(type : string) : Observable<DoctorDto[]> {
    return this._http.get<DoctorDto[]>(this._urlgetdoctors + type);
  }

  getTimes(doctorDate : DoctorDateDTO) : Observable<IntervalDTO[]>{
    return this._http.put<IntervalDTO[]>(this._urlgettimes, doctorDate);
  }

  createAppointment(appointment : AppointmentDTO){
    return this._http.post(this._urlsave, appointment);
  }

  getTimesForselectedDoctor() : Observable<IntervalDTO[]>{
    return this._http.get<IntervalDTO[]>(this._urlgettimesselecteddoctor);
  }

  createAppointmentSelectedDoctor(appointment : AppointmentDTO){
    return this._http.post(this._urlsaveselecteddoctor, appointment);
  }

}
