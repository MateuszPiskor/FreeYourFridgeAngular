import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MealDto} from '../_models/mealDto';
import { DailyMealDto } from '../_models/dailyMealSimpleDto';
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
  /**
   * the second url to not broke someone's else idea with "meal"
   */
  basedUrl2 = environment.apiUrl + 'dailymeal';
  // currentDate: number;

  constructor(private http: HttpClient) {}

  addMeal(model: any) {
    return this.http.post(this.basedUrl, model);
  }

  addDailyMeal(model: any) {
    return this.http.post(this.basedUrl2+'dailymeal', model, httpOptions);
  }

  //get current DailyMeal
  getDailyMeal(id):Observable<DailyMealDto>
  {
    return this.http.get<DailyMealDto>(this.basedUrl+'dailymeal/'+id, httpOptions);
  }

  getDailyMeals():Observable<DailyMealDto[]>
  {
    return this.http.get<DailyMealDto[]>(this.basedUrl+'dailymeal/', httpOptions);
  }
}
