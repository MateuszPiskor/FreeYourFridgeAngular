import { Component, OnInit } from '@angular/core';
import { DailyMealSimpleDto } from '../_models/dailyMealSimpleDto';
import { AlertifyjsService } from '../_services/alertifyjs.service';
import { ActivatedRoute } from '@angular/router';
import { DealMealService } from '../_services/dealMeal.service';

@Component({
  selector: 'app-dailyMeal',
  templateUrl: './dailyMeal.component.html',
  styleUrls: ['./dailyMeal.component.scss'],
})
export class DailyMealComponent implements OnInit {
  dailyMealsToday: Array<DailyMealSimpleDto>;
  dailyMeal: DailyMealSimpleDto;

  constructor(
    private mealService: DealMealService,
    private alertify: AlertifyjsService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.LoadTodayMeals();
  }

  /**
   * Loads list of daily meals eaten per a day
   */
  private LoadTodayMeals() {
    this.mealService.getDailyMeals().subscribe(
      (response) => {
        this.dailyMealsToday = response;
        console.log(this.dailyMealsToday[0]);
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  showDailyMeal(id: number) {
    this.mealService.getDailyMeal(id).subscribe(
      (response) => {
        this.dailyMeal = response;
      },
      (error) => {
          this.alertify.error(error);
      }
    );
  }
}
