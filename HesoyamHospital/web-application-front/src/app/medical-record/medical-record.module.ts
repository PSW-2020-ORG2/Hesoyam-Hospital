import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShowMedicalRecordComponent } from './show-medical-record/show-medical-record.component';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';



@NgModule({
  declarations: [ShowMedicalRecordComponent],
  imports: [
    CommonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule
  ]
})
export class MedicalRecordModule { }
