import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable, of, throwError } from 'rxjs';
import { Fridge } from '../_models/fridge';
import {IngredientDto} from '../_models/ingredientDto';
import { catchError, delay, map } from 'rxjs/operators';


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
updateIngredient(id: number, ingredient: IngredientDto):Observable<IngredientDto>{
  return this.http.post<IngredientDto>(this.baseUrl + 'fridge/' + id, ingredient);
}

}
