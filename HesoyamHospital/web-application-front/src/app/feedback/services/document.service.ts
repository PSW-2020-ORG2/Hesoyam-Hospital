import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DocumentDTO } from '../DTOs/document-dto';
import { SearchCriteriaDTO } from '../DTOs/search-criteria-dto';
import { AdvancedSearchCriteria } from '../DTOs/advanced-search-criteria';
import { AuthenticationService } from 'src/app/authentication/service/authentication.service';
import { ReportDTO } from '../DTOs/report-dto';
import { PrescriptionDTO } from '../DTOs/prescription-dto';

@Injectable({
  providedIn: 'root'
})
export class DocumentService {

  private _urlgetall:string = "http://localhost:57874/gateway/document/" + this.authService.getId();
  private _urlpost:string = "http://localhost:57874/gateway/document/simple-search/" + this.authService.getId();
  private _urlpostadvanced:string = "http://localhost:57874/gateway/document/advanced-search/" + this.authService.getId();
  private _urlgetreport:string = "http://localhost:57874/gateway/document/report/";
  private _urlgetprescription:string = "http://localhost:57874/gateway/document/prescription/";

  constructor( private _http : HttpClient, private authService : AuthenticationService) { }

  getAll() : Observable<DocumentDTO[]> {
    return this._http.get<DocumentDTO[]>(this._urlgetall);
  }

  getReport(_appointmentId : number) : Observable<ReportDTO> {
    return this._http.get<ReportDTO>(this._urlgetreport + _appointmentId);
  }

  getPrescription(_appointmentId : number) : Observable<PrescriptionDTO> {
    return this._http.get<PrescriptionDTO>(this._urlgetprescription + _appointmentId);
  }

  post(searchCriteria : SearchCriteriaDTO) : Observable<DocumentDTO[]> {
    return this._http.post<DocumentDTO[]>(this._urlpost, searchCriteria);
}

postAdvanced(searchCriteria : AdvancedSearchCriteria) : Observable<DocumentDTO[]> {
  return this._http.post<DocumentDTO[]>(this._urlpostadvanced, searchCriteria);
}
}
