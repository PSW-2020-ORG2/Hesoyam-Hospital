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
import { LoginFormComponent } from './authentication/login-form/login-form.component';
import { RouteGuardService } from './helpers/route-guard.service';
import { MainPageComponent } from './authentication/main-page/main-page.component';
import { ReportComponent } from './feedback/patient/report/report.component';
import { PrescriptionComponent } from './feedback/patient/prescription/prescription.component';
import { LandingPageComponent } from './feedback/public/landing-page/landing-page.component';
import { StatisticsComponent } from './feedback/admin/statistics/statistics.component';

const routes: Routes = [
  {path: '', redirectTo: '/hesoyamhospital', pathMatch: 'full'},
  {path: 'feedback/patient/post', component: PostFeedbackComponent, canActivate: [RouteGuardService], data: { expectedRole: 'Patient'} },
  {path: 'survey/survey-form/:id', component:SurveysAndSectionsComponent, canActivate: [RouteGuardService], data: { expectedRole: 'Patient'}},
  {path: 'survey/survey-results', component:SurveysResultsComponent, canActivate: [RouteGuardService], data: { expectedRole: 'Admin'}},
  {path: 'survey/survey-doctors', component:SurveysDoctorsComponent, canActivate: [RouteGuardService], data: { expectedRole: 'Admin'}},
  {path:'medical-record', component: ShowMedicalRecordComponent, canActivate: [RouteGuardService], data: { expectedRole: 'Patient'}},
  {path:'appointment-recommendation', component: AppointmentRecommendationComponent, canActivate: [RouteGuardService], data: { expectedRole: 'Patient'}},
  {path: 'standard-appointment', component: StandardAppointmentComponent, canActivate: [RouteGuardService], data: { expectedRole: 'Patient'}},
  {path: 'choose-scheduling', component: ChooseSchedulingTypeComponent, canActivate: [RouteGuardService], data: { expectedRole: 'Patient'}},
  {path: 'selected-doctor', component: SelectedDoctorComponent, canActivate: [RouteGuardService], data: { expectedRole: 'Patient'}},
  {path: 'main-page', component: MainPageComponent, canActivate: [RouteGuardService], data: { expectedRole: 'Patient'}},
  {path: 'block-patients', component: BlockPatientsComponent, canActivate: [RouteGuardService], data: { expectedRole: 'Admin'}},
  {path: 'scheduling-statistics', component: StatisticsComponent, canActivate: [RouteGuardService], data: { expectedRole: 'Admin'}},
  {path: 'feedback', loadChildren: () => import('./feedback/feedback.module').then(mod => mod.FeedbackModule)},
  {path: 'registration', loadChildren: () => import('./registration/registration.module').then(mod => mod.RegistrationModule)},
  {path: 'documents/simple-search', component: SimpleSearchComponent, canActivate: [RouteGuardService], data: { expectedRole: 'Patient'}},
  {path: 'documents/advanced-search', component: AdvancedSearchComponent, canActivate: [RouteGuardService], data: { expectedRole: 'Patient'}},
  {path: 'login', component: LoginFormComponent},
  {path: 'report/:id', component: ReportComponent, data: { expectedRole: 'Patient'}},
  {path: 'prescription/:id', component: PrescriptionComponent, data: { expectedRole: 'Patient'}},
  {path: 'hesoyamhospital', component: LandingPageComponent},
  {path:'**', component: PageNotFoundComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
