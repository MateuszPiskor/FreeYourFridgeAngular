import { Injectable } from '@angular/core';
import { DailyMealDetailsDto } from '../_models/dailyMealDetailsDto';

@Injectable({
  providedIn: 'root'
})
export class CalculateService {
  dailyMealDeails:DailyMealDetailsDto;
  constructor() { }

  calcCalcPerWeight(dailyMealDeails:DailyMealDetailsDto):number
  {
    return (dailyMealDeails.nutrition.nutrients[0].amount*dailyMealDeails.grams)
    /dailyMealDeails.nutrition.weightPerServing.amount;
  }

}
