import { Component } from '@angular/core';
import { AuthenticationService } from './authentication/service/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'web-application-front';
  
  constructor(public _authService : AuthenticationService) { }


}
