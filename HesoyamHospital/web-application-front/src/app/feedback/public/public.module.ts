import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublicRoutingModule } from './public-routing.module';
import { PublishedFeedbackComponent } from './published-feedback/published-feedback.component';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [PublishedFeedbackComponent],
  imports: [
    CommonModule,
    PublicRoutingModule,
    MatTableModule,
    MatButtonModule
  ]
})
export class PublicModule { }
