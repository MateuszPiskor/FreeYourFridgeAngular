import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class DealMealService {
  basedUrl = environment.apiUrl + 'meal';

  constructor(private http: HttpClient) {}

  addMeal(model: any) {
    return this.http.post(this.basedUrl, model);
  }
}
