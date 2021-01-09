import { Injectable } from '@angular/core';
import { 
  Router,
  CanActivate,
  ActivatedRouteSnapshot
} from '@angular/router';
import { AuthenticationService } from '../authentication/service/authentication.service';

@Injectable({
  providedIn: 'root'
})
@Injectable()
export class RouteGuardService implements CanActivate 
{  
  constructor(public auth: AuthenticationService, public router: Router) {}  
  canActivate(route: ActivatedRouteSnapshot): boolean {
    const expectedRole = route.data.expectedRole;    
    if (!this.auth.isAuthenticated() || this.auth.getRole() !== expectedRole){
      if(this.auth.getRole() == 'Patient'){
        this.router.navigate(['main-page']);
      }
      else if (this.auth.getRole() == 'Admin'){
        this.router.navigate(['feedback/public/allFeedback']);
      }
      else {
        this.router.navigate(['login']);
      }
      return false;
    }
    return true;
  }}
