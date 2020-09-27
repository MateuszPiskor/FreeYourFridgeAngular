import { Component, OnInit } from '@angular/core';
import { Data } from '../../data';
import { DealMealService } from 'src/app/_services/dealMeal.service';
import { AlertifyjsService } from 'src/app/_services/alertifyjs.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DailyMealDetailsDto,DailyMealFlat } from 'src/app/_models/dailyMealDetailsDto';
import { Step } from 'src/app/_models/steps';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-daily-meal-details',
  templateUrl: './daily-meal-details.component.html',
  styleUrls: ['./daily-meal-details.component.css'],
})
export class DailyMealDetailsComponent implements OnInit {
  dailyMealDetails:DailyMealDetailsDto;
  stepsToShow: Array<Step>

  constructor(
    private dailyMealService: DealMealService,
    private data: Data,
    private alertify: AlertifyjsService,
    private route: ActivatedRoute,
    private routeDirection: Router
  ) {}


  ngOnInit(): void {
    this.loadDailyMeal();
  }

  loadDailyMeal() {
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
      userRemarks:form.value
    }).subscribe(
      response=>this.alertify.success("The daily meal has been updated"),
      error=>{this.alertify.error(error)});
  }
}
