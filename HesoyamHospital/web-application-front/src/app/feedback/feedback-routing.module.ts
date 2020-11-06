import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';

const routes: Routes = [
  {
    path: 'admin', loadChildren: () => import('./admin/admin.module').then(mod => mod.AdminModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeedbackRoutingModule { }