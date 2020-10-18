import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { ActivityLevel, User } from 'src/app/_models/user';
import { ActivatedRoute } from '@angular/router';
import { AlertifyjsService } from 'src/app/_services/alertifyjs.service';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/_services/user.service';
import { AuthService } from '../../_services/auth.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.scss']
})
export class MemberEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  user: User;
  activity:ActivityLevel;
  ActivityLevel = ActivityLevel;
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any){
    if(this.editForm.dirty){
      $event.returnValue = true;
    }
  }
  // tslint:disable-next-line: max-line-length
  constructor(private route: ActivatedRoute, private alertify: AlertifyjsService, private userService: UserService, private authService: AuthService) { }

  ngOnInit() {
    this.route.data.subscribe(data =>{
      this.user = data['user'];
    });
  }

  updateUser() {
    this.user.activityLevel = this.activity;
    console.log(this.user.activityLevel);
    this.userService.updateUser(this.authService.decodedToken.nameid , this.user).subscribe(next => {
      this.alertify.success('Profile update succesfully');
      this.editForm.reset(this.user);
      console.log(this.user.activityLevel);
    }, error => {
      this.alertify.error(error);
    });
  }

}
