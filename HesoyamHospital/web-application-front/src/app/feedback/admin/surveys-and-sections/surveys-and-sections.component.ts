import { Component, OnInit } from '@angular/core';
import { FeedbackService } from '../../services/feedback.service'
import { SurveyDTO} from '../../services/feedback.service';

@Component({
  selector: 'app-surveys-and-sections',
  templateUrl: './surveys-and-sections.component.html',
  styleUrls: ['./surveys-and-sections.component.css']
})
export class SurveysAndSectionsComponent implements OnInit {

  public SurveyDTO;
  

  constructor(private _feedbackService: FeedbackService) { }
  

  ngOnInit(): void {
  }
  submit() {
    
  }


}
