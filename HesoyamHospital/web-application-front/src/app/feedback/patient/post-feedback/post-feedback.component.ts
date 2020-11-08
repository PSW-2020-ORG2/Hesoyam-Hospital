import { Component } from '@angular/core';
import { FeedbackDTO } from '../../DTOs/feedback-dto';
import { FeedbackService } from '../../services/feedback.service'

@Component({
  selector: 'app-post-feedback',
  templateUrl: './post-feedback.component.html',
  styleUrls: ['./post-feedback.component.css']
})
export class PostFeedbackComponent {

  public feedbackDTO = new FeedbackDTO('', true, true);
  public _anonymous;
  public _public;

  constructor(private _feedbackService : FeedbackService) {
    this._anonymous = 0;
    this._public = 0;
  }

  submit() {
    this.prepareFeedback();
    this._feedbackService.post(this.feedbackDTO).subscribe(
      (val) => {
        this.provideFeedback();
      });
  }

  provideFeedback() {
    let message = "Vaš komentar je uspešno poslat. ";
    let visibleMessage = "Ukoliko administrator odluči da Vaš komentar bude objavljen, on će biti dostupan svim posetiocima sajta.";
    if (this._public === 0)
      alert(message + visibleMessage);
    else
      alert(message);
  }

  prepareFeedback() {
    this.feedbackDTO.Anonymous = this._anonymous == 0 ? false : true;
    this.feedbackDTO.Public = this._public == 0 ? true : false;
  }
}
