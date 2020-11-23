import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PatientRoutingModule } from './patient-routing.module';
import { SimpleSearchComponent } from './simple-search/simple-search.component';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [SimpleSearchComponent],
  imports: [
    CommonModule,
    PatientRoutingModule,
    MatTableModule,
    MatButtonModule
  ]
})
export class PatientModule { }
