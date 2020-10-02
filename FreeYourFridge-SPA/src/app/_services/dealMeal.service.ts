import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MealDto} from '../_models/mealDto';
import { DailyMealSimpleDto } from '../_models/dailyMealSimpleDto';
import { DailyMealDetailsDto, DailyMealFlat, DmFlat } from "../_models/dailyMealDetailsDto";
import { Observable } from 'rxjs';
import { map, tap} from 'rxjs/operators'
import { DailyMealToSend } from '../_models/dailyMealToSendDto';


/**
 * czym jest local storage?
 */
const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token'),
    'headers': 'headers',
    'responseType': 'application/json',
    'Content-Type':'application/json',
    'Accept-Encoding':'gzip, deflate, br'
  })
};

@Injectable({
  providedIn: 'root',
})
export class DealMealService {
  // basedUrl = environment.apiUrl + 'meal';
  /**
   * the second url to not change "meal" story
   */
  basedUrl2 = environment.apiUrl + 'dailymeal/';
  // currentDate: number;
  // private dailyMealToSend:DailyMealToSend;

  constructor(private http: HttpClient) {}

  // addMeal(model: any) {
  //   return this.http.post(this.basedUrl, model);
  // }

  addDailyMeal(dailyMealToSend:DailyMealToSend) {
    return this.http.post<DailyMealToSend>(this.basedUrl2, dailyMealToSend, httpOptions);
  }

  //get current DailyMeal
  getDailyMeal(id):Observable<DailyMealSimpleDto>
  {
    return this.http.get<DailyMealSimpleDto>(this.basedUrl2+id, httpOptions);
  }

  getDailyMealDetails(id):Observable<DailyMealDetailsDto>
  {
    return this.http.get<DailyMealDetailsDto>(`${this.basedUrl2}${id}/details`);
  }

  getDailyMeals():Observable<DailyMealSimpleDto[]>
  {
    return this.http.get<DailyMealSimpleDto[]>(this.basedUrl2, httpOptions);
  }

  updateDailyMeal(dailyMealToSend:DailyMealToSend):Observable<void>
  {
    return this.http.put<void>(this.basedUrl2,dailyMealToSend,httpOptions);
  }

  deleteDailyMeal(dMealId:number):Observable<void>
  {
    return this.http.delete<void>(this.basedUrl2+`${dMealId}`);
  }

  // getFlatMeal(dailyMealDetails:DailyMealDetailsDto):DmFlat
  // {
  //   return
  //   {
  //     id: dailyMealDetails.id;
  //     title: dailyMealDetails.title;
  //     image: dailyMealDetails.image;
  //     grams: dailyMealDetails.grams;
  //     readyInMinute: dailyMealDetails.readyInMinute;
  //     userRemarks: dailyMealDetails.userRemarks;
  //     timeOfLastMeal: dailyMealDetails.timeOfLastMeal;
  //     nutrients: dailyMealDetails.nutrition.nutrients;
  //     caloricbreakdown: dailyMealDetails.nutrition.caloricbreakdown;
  //     steps: dailyMealDetails.instructions[0].steps;
  //   };
  // }
}
