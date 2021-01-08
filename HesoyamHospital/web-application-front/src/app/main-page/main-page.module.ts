import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MainPageRoutingModule } from './main-page-routing.module';
import { PatientMainPageComponent } from './patient-main-page/patient-main-page.component';


@NgModule({
  declarations: [PatientMainPageComponent],
  imports: [
    CommonModule,
    MainPageRoutingModule
  ]
})
export class MainPageModule { }
