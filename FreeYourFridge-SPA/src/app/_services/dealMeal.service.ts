import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MealDto} from '../_models/mealDto';
import { DailyMealSimpleDto } from '../_models/dailyMealSimpleDto';
import { DailyMealDetailsDto } from "../_models/dailyMealDetailsDto";
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
  getDailyMeal(id):Observable<DailyMealSimpleDto>
  {
    return this.http.get<DailyMealSimpleDto>(this.basedUrl+'dailymeal/'+id, httpOptions);
  }

  getDailyMealDetails(id):Observable<DailyMealDetailsDto>
  {
    return this.http.get<DailyMealDetailsDto>(`${this.basedUrl}dailymeal/${id}/details`);
  }

  getDailyMeals():Observable<DailyMealSimpleDto[]>
  {
    return this.http.get<DailyMealSimpleDto[]>(this.basedUrl+'dailymeal/', httpOptions);
  }


}
