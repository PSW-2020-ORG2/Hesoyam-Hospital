import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
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

  private _url:string = 'http://localhost:52166/api/feedback/unpublished';
  private _urlID:string = 'http://localhost:52166/api/feedback/';

  constructor(private http: HttpClient) { }

  getUnpublishedFeedbacks(): Observable<Feedback[]>{
    return this.http.get<Feedback[]>(this._url);
  }

  publishFeedback(id: number) {
    console.log(id);
    return this.http.get(this._urlID+id);
  }
}
