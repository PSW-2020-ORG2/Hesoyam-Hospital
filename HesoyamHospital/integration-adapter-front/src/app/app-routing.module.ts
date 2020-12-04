import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PharmacyRegistrationComponent } from './pharmacy-registration/pharmacy-registration.component';
const routes: Routes = [
    { path: '', component: PharmacyRegistrationComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
