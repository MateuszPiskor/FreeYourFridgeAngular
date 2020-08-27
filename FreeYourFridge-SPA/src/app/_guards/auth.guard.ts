import { Injectable } from '@angular/core';
import { CanActivate, Router} from '@angular/router';
import {AuthService} from '../_services/auth.service';
import {AlertifyjsService} from '../_services/alertifyjs.service';

@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, 
    private router: Router, 
    private alterify: AlertifyjsService) {};

  canActivate(): boolean  {
    if(this.authService.loggedIn()){
      return true;
    }
    this.alterify.error('First, you must log in!!!');
    this.router.navigate(['/home']);
  }
  
}
