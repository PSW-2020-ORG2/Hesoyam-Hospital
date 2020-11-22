import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/shared/material/material.module';
import { DocumentsRoutingModule } from './documents-routing.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    DocumentsRoutingModule,
    MaterialModule
  ]
})
export class DocumentsModule { }
