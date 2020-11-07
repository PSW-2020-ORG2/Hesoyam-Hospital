import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FeedbackRoutingModule } from './feedback-routing.module';
import { PatientModule } from './patient/patient.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FeedbackRoutingModule,
    PatientModule
  ]
})
export class FeedbackModule { }
