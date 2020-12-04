import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PharmacyRegistrationComponent } from './pharmacy-registration/pharmacy-registration.component';
import { ActionBenefitComponent } from './action-benefit/action-benefit.component';

const routes: Routes = [
    { path: '', component: PharmacyRegistrationComponent },
    { path: 'action-benefit', component: ActionBenefitComponent } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
