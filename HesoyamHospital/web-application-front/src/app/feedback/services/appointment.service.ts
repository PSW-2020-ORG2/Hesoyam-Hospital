import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DoctorDto } from '../../medical-record/DTOs/doctor-dto';
import { DoctorDateDTO } from '../patient/standard-appointment/DTOs/DoctorDateDTO';
import { TimeInterval } from '../DTOs/time-interval';
import { IntervalDTO } from '../patient/standard-appointment/DTOs/IntervalDTO';
import { AppointmentDTO } from '../patient/standard-appointment/DTOs/AppointmentDTO';
import { DoctorIntervalDto } from '../DTOs/doctor-interval-dto';
import { PriorityIntervalDTO } from '../DTOs/priority-interval-dto';
import { BlockPatientDto } from '../DTOs/block-patient-dto';
import { BlockPatientsComponent } from '../admin/block-patients/block-patients.component';
import { AuthenticationService } from 'src/app/authentication/service/authentication.service';


export interface Doctor {
  userName: string;
  fullName: string;
}

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  private _urlgetdoctors:string = "http://localhost:57874/gateway/appointmentscheduling/getDoctorsByType/";
  private _urlgettimes:string = "http://localhost:57874/gateway/appointmentscheduling/getTimesForDoctor/";
  private _urlsave:string = "http://localhost:57874/gateway/appointmentscheduling/saveAppointment";
  private _urlgettimesselecteddoctor:string = "http://localhost:57874/gateway/appointmentscheduling/getTimesForSelectedDoctor/" + this.authService.getId();
  private _urlsaveselecteddoctor:string = "http://localhost:57874/gateway/appointmentscheduling/saveSelectedDoctorAppointment";
  private _urlgetrecommendedtimes:string = "http://localhost:57874/gateway/appointmentscheduling/recommendation";
  private _urlSuspicious:string = "http://localhost:57874/gateway/appointment/getSuspiciousPatients";
  private _urlBlock:string = "http://localhost:57874/gateway/appointment/block/";

  constructor( private _http : HttpClient, private authService : AuthenticationService) { }

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

  getRecommendedTimes(doctorInterval : DoctorIntervalDto) : Observable<PriorityIntervalDTO[]>{
    return this._http.post<PriorityIntervalDTO[]>(this._urlgetrecommendedtimes, doctorInterval);
  }

  getSuspiciousPatients() : Observable<BlockPatientDto[]>{
    return this._http.get<BlockPatientDto[]>(this._urlSuspicious);
  }

  blockPatient(username : string){
    return this._http.put(this._urlBlock + username, "");
  }
}
