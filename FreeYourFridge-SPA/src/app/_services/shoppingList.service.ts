import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ShoppingListService {
  basedUrl = environment.apiUrl + 'shoppingList';

  constructor(private http: HttpClient) {}

  addIngredient(model: any) {
    return this.http.post(this.basedUrl, model);
  }
}
