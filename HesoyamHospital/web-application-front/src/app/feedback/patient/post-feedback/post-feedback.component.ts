import { Component } from '@angular/core';
import { FeedbackDTO } from '../../DTOs/feedback-dto';

@Component({
  selector: 'app-post-feedback',
  templateUrl: './post-feedback.component.html',
  styleUrls: ['./post-feedback.component.css']
})
export class PostFeedbackComponent {

  public feedbackDTO = new FeedbackDTO('aaa', true, true);
  public anonymity;
  public visibility;

  constructor() {
    this.anonymity = 0;
    this.visibility = 0;
  }

  submit() {
    let message = "Vaš komentar je uspešno poslat. ";
    let visibleMessage = "Ukoliko administrator odluči da Vaš komentar bude objavljen, on će biti dostupan svim posetiocima sajta.";
    if (this.visibility === 0)
      alert(message+visibleMessage);
    else
      alert(message);
  }
}
