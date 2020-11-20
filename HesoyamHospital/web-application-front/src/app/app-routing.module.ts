import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PostFeedbackComponent } from './feedback/patient/post-feedback/post-feedback.component';
import { MedicalRecordModule } from './medical-record/medical-record.module';
import { ShowMedicalRecordComponent } from './medical-record/show-medical-record/show-medical-record.component';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';

const routes: Routes = [
  {path: '', redirectTo: '/feedback/patient/post', pathMatch: 'full'},
  {path: 'feedback/patient/post', component: PostFeedbackComponent},
  {path:'medical-record', component: ShowMedicalRecordComponent},
  {
    path: 'feedback', loadChildren: () => import('./feedback/feedback.module').then(mod => mod.FeedbackModule)
  },
  {path:'**', component: PageNotFoundComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
