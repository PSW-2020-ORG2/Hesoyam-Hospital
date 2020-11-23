import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DocumentSearchCriteria } from '../patient/DTOs/document-search-criteria';
import { DocumentDTO } from '../patient/DTOs/document-dto';

@Injectable({
  providedIn: 'root'
})
export class DocumentsService {

  private _urlSimpleSearch:string = "http://localhost:52166/api/documents/simple-search";

  constructor(private _http : HttpClient) { }

  simpleSearchDocuments(criteria : DocumentSearchCriteria): Observable<DocumentDTO[]> {
      return this._http.post<any>(this._urlSimpleSearch, criteria);
  }
}
