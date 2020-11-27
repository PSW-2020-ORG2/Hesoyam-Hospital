import { Component, OnInit } from '@angular/core';
import { FeedbackService } from '../../services/feedback.service';
import { SectionDTO } from '../../services/feedback.service';

@Component({
  selector: 'app-surveys-results',
  templateUrl: './surveys-results.component.html',
  styleUrls: ['./surveys-results.component.css']
})
export class SurveysResultsComponent implements OnInit {

  displayedColumns: string[] = ['AnswerOne', 'AnswerTwo', 'AnswerThree', 'AnswerFour'];
  public dataSource: SectionDTO[] = [];

  constructor(private _feedbackService: FeedbackService) { }

  ngOnInit(): void {
    this._feedbackService.getDoctorSections().subscribe((data) => this.dataSource = data);
  }

}
