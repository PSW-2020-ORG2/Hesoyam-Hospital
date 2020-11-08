import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { NewFeedbackDto } from '../../DTOs/new-feedback-dto';
import { FeedbackService } from '../../services/feedback.service'

@Component({
  selector: 'app-post-feedback',
  templateUrl: './post-feedback.component.html',
  styleUrls: ['./post-feedback.component.css']
})
export class PostFeedbackComponent {

  public feedbackDTO = new NewFeedbackDto('', true, true);
  public _anonymous;
  public _public;

  constructor(private _feedbackService : FeedbackService, private _snackBar: MatSnackBar) {
    this._anonymous = 0;
    this._public = 0;
  }

  submit() {
    this.prepareFeedback();
    this._feedbackService.post(this.feedbackDTO).subscribe(
      (val) => {
        this.provideFeedback();
        this.reset();
      });
  }

  provideFeedback() {
    let message = "Vaš komentar je uspešno poslat. ";
    let visibleMessage = "Ukoliko administrator odluči da Vaš komentar bude objavljen, on će biti dostupan svim posetiocima sajta.";
    if (this.feedbackDTO.Public)
      this.openSnackBar(message + visibleMessage, "U redu");
    else
      this.openSnackBar(message, "U redu");
  }

  prepareFeedback() {
    this.feedbackDTO.Anonymous = this._anonymous == 0 ? false : true;
    this.feedbackDTO.Public = this._public == 0 ? true : false;
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 10000,
    });
  }

  reset() {
    this.feedbackDTO.Comment = '';
  }
}
