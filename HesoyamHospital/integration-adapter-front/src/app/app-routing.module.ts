import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PharmacyRegistrationComponent } from './pharmacy-registration/pharmacy-registration.component';
import { ActionBenefitComponent } from './action-benefit/action-benefit.component';
import { PrescribeTherapyComponent } from './prescribe-therapy/prescribe-therapy.component'
import { SpecificationComponent } from './specification/specification.component'
import {MedicineAvailabilityComponent} from './medicine-availability/medicine-availability.component'
import { UrgentMedicineProcurementRequestComponent } from './urgent-medicine-procurement-request/urgent-medicine-procurement-request.component'
import { UrgentMedicineProcurementListComponent } from './urgent-medicine-procurement-list/urgent-medicine-procurement-list.component'
import { TenderDisplayComponent } from './tender-display/tender-display.component';

const routes: Routes = [
    { path: '', component: PharmacyRegistrationComponent },
    { path: 'action-benefit', component: ActionBenefitComponent } ,
    { path: 'prescribe-therapy', component: PrescribeTherapyComponent},
    { path: 'specification', component: SpecificationComponent},
    { path: 'medicine-availability', component: MedicineAvailabilityComponent},
    { path: 'urgent-medicine-procurement-request', component:UrgentMedicineProcurementRequestComponent },
    { path: 'urgent-medicine-procurement-list', component:UrgentMedicineProcurementListComponent }
    { path: 'medicine-availability', component: MedicineAvailabilityComponent},
    { path: 'tender-display' , component: TenderDisplayComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
