import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  constructor(private authService: AuthService, private _location:Location) { }

  ngOnInit() {
  }
  register(){
    this.authService.register(this.model).subscribe(() => {
      console.log('register succesful');
    }, error => {
      console.log(error);
    });
    this._location.back();
  }

  cancel(){
    this.cancelRegister.emit(false);
    console.log('canclled');
  }

}
