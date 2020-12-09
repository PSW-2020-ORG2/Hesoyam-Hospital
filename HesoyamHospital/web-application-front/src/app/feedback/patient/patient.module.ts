import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PatientRoutingModule } from './patient-routing.module';
import { PostFeedbackComponent } from './post-feedback/post-feedback.component';
import { MaterialModule } from 'src/app/shared/material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { SimpleSearchComponent } from './simple-search/simple-search.component';
import {MatCheckboxModule} from '@angular/material/checkbox'; 
import {MatDatepickerModule} from '@angular/material/datepicker';
import { AdvancedSearchComponent } from './advanced-search/advanced-search.component';
import { AppointmentRecommendationComponent } from './appointment-recommendation/appointment-recommendation.component';
import { StandardAppointmentComponent } from './standard-appointment/standard-appointment.component';
import { ChooseSchedulingTypeComponent } from './choose-scheduling-type/choose-scheduling-type.component';
import { SelectedDoctorComponent } from './selected-doctor/selected-doctor.component';



@NgModule({
  declarations: [PostFeedbackComponent, SimpleSearchComponent, AdvancedSearchComponent, AppointmentRecommendationComponent, StandardAppointmentComponent, ChooseSchedulingTypeComponent, SelectedDoctorComponent],
  imports: [
    CommonModule,
    PatientRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule,
    MatCheckboxModule,
    MatDatepickerModule
  ]
})
export class PatientModule { }
