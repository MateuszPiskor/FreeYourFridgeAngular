import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FavouredToList } from '../_models/Favoured/favouredToList';
import { RecipeToDetails } from '../_models/recipeToDetails';
import { FavouredDto } from '../_models/Favoured/favouredDto';

@Injectable({
  providedIn: 'root',
})
export class FavouredService {
  basedUrl = environment.apiUrl + 'Favoured';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  constructor(private http: HttpClient) {}

  addFavoured(model: any) {
    return this.http.post(this.basedUrl, model, this.httpOptions);
  }

  getFavoureds(): Observable<FavouredDto[]> {
    return this.http.get<FavouredDto[]>(this.basedUrl, this.httpOptions);
  }
}
