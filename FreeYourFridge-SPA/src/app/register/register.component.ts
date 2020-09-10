import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import {Location} from '@angular/common';
import {AlertifyjsService } from '../_services/alertifyjs.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  constructor(private authService: AuthService, private _location: Location, private alertify: AlertifyjsService, private route: Router) { }

  ngOnInit() {
  }
  register(){
    this.authService.register(this.model).subscribe(() => {
      this.alertify.success('Register succesful');
    }, error => {
      this.alertify.error('User alredy exists');
      this.model.username = '';
      this.model.password = '';
      this.model.email = '';
      this.model.gender = '';
      this.model.age = '';
      this.model.weight = '';
      this.model.height = '';
    });
    this.route.navigate(['/home']);
    this.model.username = '';
    this.model.password = '';
    this.model.email = '';
    this.model.gender = '';
    this.model.age = '';
    this.model.weight = '';
    this.model.height = '';
  }

  cancel(){
    this.cancelRegister.emit(false);
    console.log('canclled');
  }

}
