import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SimpleSearchComponent } from './feedback/patient/simple-search/simple-search.component';
import { PostFeedbackComponent } from './feedback/patient/post-feedback/post-feedback.component';
import { ShowMedicalRecordComponent } from './medical-record/show-medical-record/show-medical-record.component';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';
import { SurveysAndSectionsComponent} from './feedback/admin/surveys-and-sections/surveys-and-sections.component'


const routes: Routes = [
  {path: '', redirectTo: '/feedback/patient/post', pathMatch: 'full'},
  {path: 'feedback/patient/post', component: PostFeedbackComponent},
  {path: 'survey/survey-form', component:SurveysAndSectionsComponent},
  {path:'medical-record', component: ShowMedicalRecordComponent},
  
  {
    path: 'feedback', loadChildren: () => import('./feedback/feedback.module').then(mod => mod.FeedbackModule)
  },
  {
    path: 'registration', loadChildren: () => import('./registration/registration.module').then(mod => mod.RegistrationModule)
  },
  {path: 'documents/simple-search', component: SimpleSearchComponent},
  {path:'**', component: PageNotFoundComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
