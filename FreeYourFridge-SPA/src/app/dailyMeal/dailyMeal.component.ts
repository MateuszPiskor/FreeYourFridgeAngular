import { Component, OnInit } from '@angular/core';
import { MealDto } from '../_models/mealDto';
import { AlertifyjsService } from '../_services/alertifyjs.service';
import { DealMealService } from '../_services/dealMeal.service';

@Component({
  selector: 'app-dailyMeal',
  templateUrl: './dailyMeal.component.html',
  styleUrls: ['./dailyMeal.component.scss']
})

export class DailyMealComponent implements OnInit {
  mealsEatenToday:Array<MealDto>;

  constructor(
    private mealService:DealMealService,
    private alertify: AlertifyjsService) { }

  ngOnInit() {
    this.LoadTodayMeals();
  }

  /**
   * Loads list of daily meals eaten per a day
  */
  private LoadTodayMeals()
  {
    this.mealService.getDailyMeals().subscribe(
      response => {
        this.mealsEatenToday = response;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
}
