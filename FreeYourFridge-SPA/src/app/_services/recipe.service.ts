import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Recipe } from '../_models/recipe';
import { Instruction } from '../_models/instruction';


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
constructor(private http: HttpClient) {}
  getRecipes(): Observable<Recipe[]>{
    return this.http.get<Recipe[]>(this.baseUrl + 'recipe', httpOptions);
  }

  getRecipe(id): Observable<Recipe> {
    return this.http.get<Recipe>(this.baseUrl + 'recipe/' + id, httpOptions);
  }

  getWidget(id): Observable<string> {
    return this.http.get<string>(this.baseUrl + 'widget/' + id, httpOptions);
  }

  getInstruction(id): Observable<Instruction[]>{
    return this.http.get<Instruction[]>(this.baseUrl + 'recipe/' + id + '/instruction', httpOptions);
  }


}
