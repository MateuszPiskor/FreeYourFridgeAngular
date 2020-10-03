import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RecipeToDetails } from '../_models/recipeToDetails';
import { Instruction } from '../_models/instruction';
import { Nutritions } from '../_models/recipeNutritions';
import { RecipeToList } from '../_models/recipeToList'
import { RecipeIngredients } from '../_models/ingredient';


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
export class RecipeService {
  baseUrl = environment.apiUrl;

  getNutrition(id): Observable<Nutritions> {
    return this.http.get<Nutritions>(this.baseUrl + 'recipe/' + id + '/nutritions', httpOptions);
  }

constructor(private http: HttpClient) {}
  getRecipes(): Observable<RecipeToList[]>{
    return this.http.get<RecipeToList[]>(this.baseUrl + 'recipe', httpOptions);
  }

  GetTimeAndScore(id): Observable<RecipeToDetails> {
    return this.http.get<RecipeToDetails>(this.baseUrl + 'recipe/' + id, httpOptions);
  }

  getInstruction(id): Observable<Instruction[]>{
    return this.http.get<Instruction[]>(this.baseUrl + 'recipe/' + id + '/instruction', httpOptions);
  }

  getIngredients(id): Observable<RecipeIngredients>{
    return this.http.get<RecipeIngredients>(this.baseUrl + 'recipe/' + id + '/ingredients', httpOptions);
  }

}
