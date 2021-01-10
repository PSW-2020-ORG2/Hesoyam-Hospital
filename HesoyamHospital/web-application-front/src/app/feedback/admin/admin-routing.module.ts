import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PublishListComponent } from './publish-list/publish-list.component';
import { MatTableModule } from '@angular/material/table';
import { SurveysAndSectionsComponent } from './surveys-and-sections/surveys-and-sections.component';
import { RouteGuardService } from 'src/app/helpers/route-guard.service';
import { BlockPatientsComponent } from './block-patients/block-patients.component';

const routes: Routes = [
  { path: 'publishlist', component: PublishListComponent, canActivate: [RouteGuardService], data: { expectedRole: 'Admin'}},
  { path: 'surveys-sections', component: SurveysAndSectionsComponent, canActivate: [RouteGuardService], data: { expectedRole: 'Patient'} }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
export const routingComponents = [ PublishListComponent , SurveysAndSectionsComponent]