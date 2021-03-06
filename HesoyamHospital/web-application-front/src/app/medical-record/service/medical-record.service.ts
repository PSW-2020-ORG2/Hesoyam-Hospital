import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MedicalRecordDto } from '../DTOs/medical-record-dto';
import { DoctorDto } from '../DTOs/doctor-dto';
import { SelectedDoctorDto } from '../DTOs/selected-doctor-dto';
import { AuthenticationService } from 'src/app/authentication/service/authentication.service';

@Injectable({
  providedIn: 'root'
})
export class MedicalRecordService {

  private _urlshowrecord:string = 'http://localhost:57874/gateway/medicalrecord/show/' + this.authService.getId();
  private _urldoctors:string = 'http://localhost:57874/gateway/medicalrecord/allGeneralDoctors';
  private _urlchange:string = 'http://localhost:57874/gateway/medicalrecord/changeSelectedDoctor';

  constructor(private _http : HttpClient, private authService : AuthenticationService) {}

  getMedicalRecord(): Observable<MedicalRecordDto>{
      return this._http.get<MedicalRecordDto>(this._urlshowrecord);
  }
  
  getGeneralDoctor(): Observable<DoctorDto[]>{
    return this._http.get<DoctorDto[]>(this._urldoctors);
  }

  changeSelectedDoctor(dto : SelectedDoctorDto){
    return this._http.post(this._urlchange, dto);
  }
}
