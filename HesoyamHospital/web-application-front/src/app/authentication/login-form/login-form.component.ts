import { Component, OnDestroy, OnInit } from '@angular/core';
import {UserLoginDTO} from '../DTOs/user-login-dto';
import { AuthenticationService } from '../service/authentication.service';
import decode from 'jwt-decode';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit, OnDestroy {
  username: string = "";
  password: string = "";
  role: number = 0;
  constructor(private _authService : AuthenticationService, private _snackBar: MatSnackBar, private router : Router) { }
  ngOnDestroy(): void {
    this._authService.loginComponent = false;
  }

  ngOnInit(): void {
    this._authService.loginComponent = true;
  }

  login() {
    let user = new UserLoginDTO(this.username, this.password, this.role == 0 ? "Patient" : "Admin");
    this._authService.logIn(user).subscribe(token => {
      localStorage.setItem('token', JSON.stringify(token));
      const tokenPayload = decode(token);
      localStorage.setItem('id', tokenPayload['nameid']);
      localStorage.setItem('username', tokenPayload['sub']);
      localStorage.setItem('role', tokenPayload['Role']);
      if(this.role == 0){
        this.router.navigate(['main-page']);
      } else this.router.navigate(['feedback/public/allFeedback']);
  },
  error => {
    this.openSnackBar(error.error, "Okay");
  });
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 10000,
    });
  }
}
