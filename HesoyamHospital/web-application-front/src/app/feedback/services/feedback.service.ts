import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NewFeedbackDto } from '../DTOs/new-feedback-dto';
import { Observable } from 'rxjs';
import {SurveyDTO} from '../DTOs/survey-dto';

export interface Feedback {
  id: number;
  userName: string;
  comment: string;
  anonymous: boolean;
  public: boolean;
  published: boolean;
}

export interface SectionDTO {
  answerOne: number;
  answerTwo: number;
  answerThree: number;
  answerFour: number;
  
}


@Injectable({
  providedIn: 'root'
})

export class FeedbackService {

  private _urlEquipmentSections:string = 'http://localhost:52166/api/survey/get-answers-per-section/Equipment';
  private _urlHygieneSections:string = 'http://localhost:52166/api/survey/get-answers-per-section/Hygiene';
  private _urlStaffSections:string = 'http://localhost:52166/api/survey/get-answers-per-section/Staff';
  private _urlDoctorSections:string = 'http://localhost:52166/api/survey/get-answers-per-section/Doctor';
  private _urlunpublished:string = 'http://localhost:52166/api/feedback/unpublished';
  private _urlpublished:string = 'http://localhost:52166/api/feedback/published';
  private _urlID:string = 'http://localhost:52166/api/feedback';
  private _urlpost:string = "http://localhost:52166/api/feedback";
  private _urlpostsurvey: string = "http://localhost:52166/api/survey/send-answers";

  constructor(private _http : HttpClient) { }

  post(feedback : NewFeedbackDto) {
      return this._http.post<any>(this._urlpost, feedback);
  }
  
  postSurvey(survey : SurveyDTO){
    return this._http.post<any>(this._urlpostsurvey, survey)
  }
  getUnpublishedFeedbacks(): Observable<Feedback[]>{
    return this._http.get<Feedback[]>(this._urlunpublished);
  }
  getDoctorSections(): Observable<SectionDTO[]>{
    return this._http.get<SectionDTO[]>(this._urlDoctorSections);
    }
  getStaffSections(): Observable<SectionDTO[]>{
    return this._http.get<SectionDTO[]>(this._urlStaffSections);
    }
  getHygieneSections(): Observable<SectionDTO[]>{
      return this._http.get<SectionDTO[]>(this._urlHygieneSections);
    }
  getEquipmentSections(): Observable<SectionDTO[]>{
      return this._http.get<SectionDTO[]>(this._urlEquipmentSections);
    }
   

  getPublishedFeedbacks(): Observable<Feedback[]>{
    return this._http.get<Feedback[]>(this._urlpublished);
  }

  publishFeedback(id: number) {
    return this._http.put(this._urlID, id);
  }
}
