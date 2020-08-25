import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyjsService } from '../_services/alertifyjs.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})

export class NavComponent implements OnInit {
  model: any = {};

  constructor(public authService: AuthService, private alertify: AlertifyjsService, private route: Router) { }

  ngOnInit() {
  }
  login(){
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('logged in successfully');
    }, error => {
      this.alertify.error('Failed to login');
    }, () =>{
      this.route.navigate(['/myProfile']);
    });
  }

    loggedIn()
    {
      return this.authService.loggedIn();
    }

    logout(){
      localStorage.removeItem("token");
      this.alertify.message('logged out');
      this.route.navigate(['/home']);
    }
  

}
