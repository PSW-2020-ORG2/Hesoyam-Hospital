import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublicRoutingModule } from './public-routing.module';
import { PublishedFeedbackComponent } from './published-feedback/published-feedback.component';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import { FlexLayoutModule } from "@angular/flex-layout";
import { LandingPageComponent } from './landing-page/landing-page.component';

@NgModule({
  declarations: [PublishedFeedbackComponent, LandingPageComponent],
  imports: [
    CommonModule,
    PublicRoutingModule,
    MatTableModule,
    MatButtonModule,
    MatCardModule,
    FlexLayoutModule
  ]
})
export class PublicModule { }
