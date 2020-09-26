import { Component, OnInit } from '@angular/core';
import { Data } from '../../data';
import { DealMealService } from 'src/app/_services/dealMeal.service';
import { AlertifyjsService } from 'src/app/_services/alertifyjs.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DailyMealDetailsDto } from 'src/app/_models/dailyMealDetailsDto';
import { Instructions, Steps } from 'src/app/_models/steps';

@Component({
  selector: 'app-daily-meal-details',
  templateUrl: './daily-meal-details.component.html',
  styleUrls: ['./daily-meal-details.component.css'],
})
export class DailyMealDetailsComponent implements OnInit {
  dailyMealDetails:DailyMealDetailsDto;
  private g:Array<Instructions>;
  private b:Array<Steps>;
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
        this.dailyMealDetails = response
      },
      (error) =>
      {this.alertify.error(error);});
  }

  updateDailyMeal(id)
  {

  }
}
