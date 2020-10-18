import { Component, OnInit } from '@angular/core';
import { Data } from '../../data';
import { DealMealService } from 'src/app/_services/dealMeal.service';
import { CalculateService } from 'src/app/_services/calculate.service';
import { AlertifyjsService } from 'src/app/_services/alertifyjs.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DailyMealDetailsDto,DailyMealFlat, DmFlat } from 'src/app/_models/dailyMealDetailsDto';
import { Step } from 'src/app/_models/steps';
import { NgForm } from '@angular/forms';
import { pipe } from 'rxjs';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-daily-meal-details',
  templateUrl: './daily-meal-details.component.html',
  styleUrls: ['./daily-meal-details.component.css'],
})
export class DailyMealDetailsComponent implements OnInit {
  dailyMealDetails:DailyMealDetailsDto;
  stepsToShow: Array<Step>;
  private user:User;

  constructor(
    private dailyMealService: DealMealService,
    private calcService:CalculateService,
    private data: Data,
    private alertify: AlertifyjsService,
    private route: ActivatedRoute,
    private routeDirection: Router,
    private authService:AuthService,
    private userService:UserService
  ) {}


  ngOnInit(): void {
    this.loadDailyMeal();
    // this.getUserDailyDemand()
  }

  private loadDailyMeal() {
    this.dailyMealService
      .getDailyMealDetails(+this.route.snapshot.params['id'])
      .subscribe((response) => {
        this.dailyMealDetails = response;
        this.stepsToShow = this.dailyMealDetails.instructions[0].steps;
        console.log(this.stepsToShow[0]);
      },
      (error) =>
      {this.alertify.error(error);}),
      console.log(`log z DAAILY MEAL details ${this.dailyMealDetails}`);;
  }

  onSubmit(form:NgForm)
  {
    this.dailyMealService.updateDailyMeal({
      id:this.dailyMealDetails.id,
      title:this.dailyMealDetails.title,
      image:this.dailyMealDetails.image,
      grams:this.dailyMealDetails.grams,
      userRemarks:form.value.notes
    }).subscribe(
      response=>this.alertify.success("The daily meal has been updated"),
      error=>{this.alertify.error(error)});
  }

  getCalculatedCalories()
  {
    return this.calcService.calcCalcPerWeight(this.dailyMealDetails);
  }

  /** ale to chyba będzie lepsze w userze a obliczenie całości na backendzie */
  // private getUserDailyDemand():number
  // {
  //   this.userService.getUser(this.authService.decodedToken.nameid).subscribe(
  //     response=> this.user = response);
  //     return this.user.dailyDemand;
  // }
}
