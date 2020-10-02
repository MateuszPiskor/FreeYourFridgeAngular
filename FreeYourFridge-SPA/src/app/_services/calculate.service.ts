import { Injectable } from '@angular/core';
import { DailyMealDetailsDto } from '../_models/dailyMealDetailsDto';

@Injectable({
  providedIn: 'root'
})
export class CalculateService {
  // dailyMealDetails:DailyMealDetailsDto;
  grams:number;


  constructor() { }
  calcCalcPerWeight(dm:DailyMealDetailsDto):number
  {
    return ((dm.nutrition.nutrients[0].amount*dm.grams)
    /dm.nutrition.weightPerServing.amount);
  }
}
