import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserLoginDTO } from '../DTOs/user-login-dto';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  loginUrl = "http://localhost:57874/gateway/login";

  constructor( private _http : HttpClient, public router: Router) { }

  logIn(user : UserLoginDTO) {
    return this._http.post(this.loginUrl, user, {responseType: 'text'});
  }

  getToken() {
    let token = localStorage.getItem('token');
    if (token == null) return token;
    return token.substr(1, token.length-2);
  }

  getRole() {
    return localStorage.getItem('role');
  }

  public isAuthenticated(): boolean 
  {    
    const token = localStorage.getItem('token');
    if (token == null) return false;
    let jwtHelper = new JwtHelperService();
    return !jwtHelper.isTokenExpired(token);
  }

  public getId(): number
  {
    return Number(localStorage.getItem('id'));
  }

  public getUsername() : string
  {
    return localStorage.getItem('username');
  }

  public logOut() {
      localStorage.removeItem('token');
      localStorage.removeItem('id');
      localStorage.removeItem('username');
      localStorage.removeItem('role');
      this.router.navigate(['login']);
  }
}
