import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';


import { PharmacyRegistrationComponent } from './pharmacy-registration/pharmacy-registration.component';
import { ActionBenefitComponent } from './action-benefit/action-benefit.component';
import { PrescribeTherapyComponent } from './prescribe-therapy/prescribe-therapy.component';
import { SpecificationComponent } from './specification/specification.component';
import { MedicineAvailabilityComponent } from './medicine-availability/medicine-availability.component';
import { UrgentMedicineProcurementRequestComponent } from './urgent-medicine-procurement-request/urgent-medicine-procurement-request.component';
import { UrgentMedicineProcurementListComponent } from './urgent-medicine-procurement-list/urgent-medicine-procurement-list.component';

import { ReactiveFormsModule ,FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { MatMenuModule } from '@angular/material/menu';
import { MatInputModule } from '@angular/material/input'
import { MatSelectModule } from '@angular/material/select'
import { MatButtonModule } from '@angular/material/button'
import { MatCheckboxModule } from '@angular/material/checkbox'
import { MatChipsModule } from '@angular/material/chips'
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import { TenderDisplayComponent } from './tender-display/tender-display.component';
import { TenderOfferDialogComponent } from './dialog/tender-offer-dialog/tender-offer-dialog.component'

import { MatDialogModule } from '@angular/material/dialog';
import { UrgentRequestDialogComponent } from './dialog/urgent-request-dialog/urgent-request-dialog.component';
import { TenderDisplayManagerComponent } from './tender-display-manager/tender-display-manager.component';
import { TenderDispayAllOffersComponent } from './tender-dispay-all-offers/tender-dispay-all-offers.component';
import { NewTenderDialogComponent } from './dialog/new-tender-dialog/new-tender-dialog.component';

import {
  NgxMatDatetimePickerModule,
  NgxMatNativeDateModule,
  NgxMatTimepickerModule
} from '@angular-material-components/datetime-picker';

@NgModule({
  declarations: [
    AppComponent,
    PharmacyRegistrationComponent,
    ActionBenefitComponent,
    PrescribeTherapyComponent,
    SpecificationComponent,
    MedicineAvailabilityComponent,
    UrgentMedicineProcurementRequestComponent,
    UrgentMedicineProcurementListComponent,
    UrgentRequestDialogComponent,
    TenderDisplayComponent,
    TenderOfferDialogComponent,
    TenderDisplayManagerComponent,
    TenderDispayAllOffersComponent,
    NewTenderDialogComponent
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
    MatMenuModule,
    MatDialogModule,
    NgxMatDatetimePickerModule,
    NgxMatTimepickerModule,
    NgxMatNativeDateModule,
    HttpClientModule
  ],
  entryComponents:[
    UrgentRequestDialogComponent,
    TenderOfferDialogComponent,
    NewTenderDialogComponent
  ],
  providers: [ ],
  bootstrap: [AppComponent]
})
export class AppModule { }
