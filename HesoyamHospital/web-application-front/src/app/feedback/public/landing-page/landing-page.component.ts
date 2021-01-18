import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/authentication/service/authentication.service';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {

  constructor(private _authService : AuthenticationService, private router : Router) { }

  ngOnInit(): void {
    if(this._authService.isAuthenticated()){
      this.router.navigate(['main-page']);
    }
  }
}
