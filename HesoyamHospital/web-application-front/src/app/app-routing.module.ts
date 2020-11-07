import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PostFeedbackComponent } from './feedback/patient/post-feedback/post-feedback.component';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';

const routes: Routes = [
  {path: '', redirectTo: '/feedback/patient/post', pathMatch: 'full'},
  {path: 'feedback/patient/post', component: PostFeedbackComponent},
  {path:'**', component: PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
