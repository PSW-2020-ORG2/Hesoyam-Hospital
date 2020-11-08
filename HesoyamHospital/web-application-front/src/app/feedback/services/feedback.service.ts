import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { NewFeedbackDto } from '../DTOs/new-feedback-dto';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {

  _url = "http://localhost:52166/api/feedback";

  constructor(private _http : HttpClient) { }

  post(feedback : NewFeedbackDto) {
      return this._http.post<any>(this._url, feedback);
  }
}
