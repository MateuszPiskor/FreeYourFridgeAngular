import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MealDto } from '../_models/mealDto';
import { Observable } from 'rxjs';


/**
 * czym jest local storage?
 */
const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token'),
    'headers': 'headers',
    'responseType': 'application/json'
  })
};


@Injectable({
  providedIn: 'root',
})
export class DealMealService {
  basedUrl = environment.apiUrl + 'meal';
  currentDate: number;

  constructor(private http: HttpClient) {}

  addMeal(model: any) {
    return this.http.post(this.basedUrl, model);
  }

  //get current DailyMeal
  getDailyMeal(id):Observable<MealDto>
  {
    return this.http.get<MealDto>(this.basedUrl+'meal/'+id, httpOptions);
  }

  getDailyMeals():Observable<MealDto[]>
  {
    return this.http.get<MealDto[]>(this.basedUrl+'meal/', httpOptions);
  }
}
