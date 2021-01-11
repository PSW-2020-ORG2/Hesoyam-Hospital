import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';


import { PharmacyRegistrationComponent } from './pharmacy-registration/pharmacy-registration.component';
import { ActionBenefitComponent } from './action-benefit/action-benefit.component';

import { ReactiveFormsModule ,FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import {  } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input'
import { MatSelectModule } from '@angular/material/select'
import { MatButtonModule } from '@angular/material/button'
import { MatCheckboxModule } from '@angular/material/checkbox'
import { MatChipsModule } from '@angular/material/chips'
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import { PrescribeTherapyComponent } from './prescribe-therapy/prescribe-therapy.component';
import { SpecificationComponent } from './specification/specification.component';
import { MedicineAvailabilityComponent } from './medicine-availability/medicine-availability.component';
import { TenderDisplayComponent } from './tender-display/tender-display.component';
import { TenderOfferDialogComponent } from './dialog/tender-offer-dialog/tender-offer-dialog.component'
import { MatDialogModule } from '@angular/material/dialog';


@NgModule({
  declarations: [
    AppComponent,
    PharmacyRegistrationComponent,
    ActionBenefitComponent,
    PrescribeTherapyComponent,
    SpecificationComponent,
    MedicineAvailabilityComponent,
    TenderDisplayComponent,
    TenderOfferDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatCheckboxModule,
    MatChipsModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatDialogModule,
    HttpClientModule
  ],
  entryComponents:[
    TenderOfferDialogComponent
  ],
  providers: [ ],
  bootstrap: [AppComponent]
})
export class AppModule { }
