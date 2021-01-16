import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FeedbackModule } from './feedback/feedback.module';
import { SharedModule } from './shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { FeedbackService } from './feedback/services/feedback.service';
import { MaterialModule } from './shared/material/material.module';
import { MedicalRecordModule} from './medical-record/medical-record.module';
import { RegistrationModule } from './registration/registration.module';
import { DocumentsModule } from './documents/documents.module';
import { RegistrationService } from './registration/services/registration.service';
import { AuthenticationModule } from './authentication/authentication.module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { Interceptor } from './helpers/interceptor.service';
import { MatTooltipModule } from '@angular/material/tooltip';
import { NgxChartsModule }from '@swimlane/ngx-charts';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FeedbackModule,
    SharedModule,
    HttpClientModule,
    MaterialModule,
    MedicalRecordModule,
    RegistrationModule,
    DocumentsModule,
    AuthenticationModule,
    MatTooltipModule,
    NgxChartsModule
  ],
  exports:[
    MatTooltipModule
  ],
  providers: [FeedbackService, RegistrationService, {
    provide: HTTP_INTERCEPTORS,
    useClass: Interceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
