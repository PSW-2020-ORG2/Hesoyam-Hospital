import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SimpleSearchComponent } from './feedback/patient/simple-search/simple-search.component';
import { AdvancedSearchComponent } from './feedback/patient/advanced-search/advanced-search.component';
import { PostFeedbackComponent } from './feedback/patient/post-feedback/post-feedback.component';
import { ShowMedicalRecordComponent } from './medical-record/show-medical-record/show-medical-record.component';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';
import { SurveysAndSectionsComponent} from './feedback/admin/surveys-and-sections/surveys-and-sections.component'
import { SurveysResultsComponent } from './feedback/admin/surveys-results/surveys-results.component';
import { SurveysDoctorsComponent } from './feedback/admin/surveys-doctors/surveys-doctors.component';
import { AppointmentRecommendationComponent } from './feedback/patient/appointment-recommendation/appointment-recommendation.component';
import { StandardAppointmentComponent } from './feedback/patient/standard-appointment/standard-appointment.component';
import { ChooseSchedulingTypeComponent } from './feedback/patient/choose-scheduling-type/choose-scheduling-type.component';
import { SelectedDoctorComponent } from './feedback/patient/selected-doctor/selected-doctor.component';
import { BlockPatientsComponent } from './feedback/admin/block-patients/block-patients.component';

const routes: Routes = [
  {path: '', redirectTo: '/feedback/patient/post', pathMatch: 'full'},
  {path: 'feedback/patient/post', component: PostFeedbackComponent},
  {path: 'survey/survey-form/:id', component:SurveysAndSectionsComponent},
  {path: 'survey/survey-results', component:SurveysResultsComponent},
  {path: 'survey/survey-doctors', component:SurveysDoctorsComponent},
  {path: 'medical-record', component: ShowMedicalRecordComponent},
  {path: 'appointment-recommendation', component: AppointmentRecommendationComponent},
  {path: 'standard-appointment', component: StandardAppointmentComponent},
  {path: 'choose-scheduling', component: ChooseSchedulingTypeComponent},
  {path: 'selected-doctor', component: SelectedDoctorComponent},
  {path: 'block-patients', component: BlockPatientsComponent},
  
  {
    path: 'feedback', loadChildren: () => import('./feedback/feedback.module').then(mod => mod.FeedbackModule)
  },
  {
    path: 'registration', loadChildren: () => import('./registration/registration.module').then(mod => mod.RegistrationModule)
  },
  {path: 'documents/simple-search', component: SimpleSearchComponent},
  {path: 'documents/advanced-search', component: AdvancedSearchComponent},
  {path:'**', component: PageNotFoundComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
