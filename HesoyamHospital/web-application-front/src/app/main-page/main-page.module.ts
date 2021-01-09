import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/shared/material/material.module';
import { NgImageSliderModule } from 'ng-image-slider'; 
import { MainPageRoutingModule } from './main-page-routing.module';
import { PatientMainPageComponent } from './patient-main-page/patient-main-page.component';


@NgModule({
  declarations: [PatientMainPageComponent],
  imports: [
    CommonModule,
    MainPageRoutingModule,
    MaterialModule
  ],
  exports: [NgImageSliderModule]
})
export class MainPageModule { }
