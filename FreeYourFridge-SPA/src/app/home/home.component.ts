import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  constructor(
    private http:HttpClient,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
  }
  registerToggle(){
    this.router.navigateByUrl('register');
  }

  cancelRegisterMode(registerMode: boolean){
    this.registerMode = registerMode;
  }
