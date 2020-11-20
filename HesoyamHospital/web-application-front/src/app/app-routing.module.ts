import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SimpleSearchComponent } from './documents/patient/simple-search/simple-search.component';
import { PostFeedbackComponent } from './feedback/patient/post-feedback/post-feedback.component';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';

const routes: Routes = [
  {path: '', redirectTo: '/feedback/patient/post', pathMatch: 'full'},
  {path: 'feedback/patient/post', component: PostFeedbackComponent},
  {
    path: 'feedback', loadChildren: () => import('./feedback/feedback.module').then(mod => mod.FeedbackModule)
  },
  {path: 'documents/simple-search', component: SimpleSearchComponent},
  {path:'**', component: PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
