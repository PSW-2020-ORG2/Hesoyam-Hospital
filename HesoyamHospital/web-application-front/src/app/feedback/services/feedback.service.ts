import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { NewFeedbackDto } from '../DTOs/new-feedback-dto';
import { Observable } from 'rxjs';

export interface Feedback {
  id: number;
  userName: string;
  comment: string;
  anonymous: boolean;
  public: boolean;
  published: boolean;
}

@Injectable({
  providedIn: 'root'
})

export class FeedbackService {

  private _urlunpublished:string = 'http://localhost:52166/api/feedback/unpublished';
  private _urlID:string = 'http://localhost:52166/api/feedback/';
  private _urlpost:string = "http://localhost:52166/api/feedback";

  constructor(private _http : HttpClient) { }

  post(feedback : NewFeedbackDto) {
      return this._http.post<any>(this._urlpost, feedback);
  }

  getUnpublishedFeedbacks(): Observable<Feedback[]>{
    return this._http.get<Feedback[]>(this._urlunpublished);
  }

  publishFeedback(id: number) {
    console.log(id);
    return this._http.get(this._urlID+id);
  }
}
