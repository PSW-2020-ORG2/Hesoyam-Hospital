import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/shared/material/material.module';
import { FormsModule } from '@angular/forms';
import { AuthenticationRoutingModule } from './authentication-routing.module';
import { LoginFormComponent } from './login-form/login-form.component';
import { MainPageComponent } from './main-page/main-page.component';


@NgModule({
  declarations: [LoginFormComponent, MainPageComponent],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    MaterialModule,
    FormsModule
  ]
})
export class AuthenticationModule { }
