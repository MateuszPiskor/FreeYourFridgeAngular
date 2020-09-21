import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/user';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-myProfile',
  templateUrl: './myProfile.component.html',
  styleUrls: ['./myProfile.component.scss']
})
export class MyProfileComponent implements OnInit {
  user: User;
  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data =>{
      this.user = data['user'];
    });
  }

}
