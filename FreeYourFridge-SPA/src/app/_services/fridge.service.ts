import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable, of, throwError } from 'rxjs';
import { Fridge } from '../_models/fridge';
import {IngredientDto} from '../_models/ingredientDto';
import {IngredientFromApi} from '../_models/ingredientFromApi';
import { catchError, delay, map } from 'rxjs/operators';
import { IngredientToApi } from '../_models/ingredientToApi';
import {ListOfIngredients} from '../_models/listOfIngredients';
import {ListOfIngredientsDto} from '../_models/ListOfingredientsDto';

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
export class FridgeService {
  baseUrl = environment.apiUrl;
  fridge: Fridge;
  ingredient: IngredientDto;

constructor(private http: HttpClient) { }

getUserFridge(userid): Observable<Fridge>{
  return this.http.get<Fridge>(this.baseUrl + 'fridge/GetFridgeByUserId/' + userid);
}
deleteIngredientFromFridge(ingredientId): Observable<IngredientDto>{
  return this.http.delete<IngredientDto>(this.baseUrl + 'fridge/' + ingredientId);
}
updateIngredient(id: number, updateIngredient):Observable<IngredientDto>{
  return this.http.post<IngredientDto>(this.baseUrl + 'fridge/' + id, updateIngredient);
}
getIngredientFromApi():Observable<ListOfIngredientsDto>{
  return this.http.get<ListOfIngredientsDto>(this.baseUrl + 'fridge/GetIngridients', httpOptions);
}
getUnitsFromApi(id: number):Observable<IngredientFromApi>{
  return this.http.get<IngredientFromApi>(this.baseUrl + 'fridge/GetUnits/' + id, httpOptions);
}
addNewIngredient(id, newIngredient): Observable<IngredientToApi>{
  return this.http.post<IngredientToApi>(this.baseUrl + 'fridge/addIngredient/' + id, newIngredient);
}

}
