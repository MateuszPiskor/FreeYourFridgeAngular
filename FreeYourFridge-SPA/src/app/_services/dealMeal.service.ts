import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Instruction } from '../_models/instruction';
import { Nutritions } from '../_models/recipeNutritions';
import { RecipeIngredients } from '../_models/ingredient';
import { MealDto } from '../_models/mealDto';


const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token'),
    'headers': 'headers',
    'responseType': 'text'

  })
};

@Injectable({
  providedIn: 'root'
})
export class DealMealService {
  basedUrl = environment.apiUrl + 'meal/';

  constructor(private http: HttpClient) {}

  addMeal(model: any){
    return this.http.post(this.basedUrl , model);  }

  // addMeal(id): Observable<DealMeal> {
  //   return this.http.get<Nutritions>(this.baseUrl + 'recipe/' + id + '/nutritions', httpOptions);
  // }

}
