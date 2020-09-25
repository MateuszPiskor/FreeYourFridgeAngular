import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})


export class FavouredService {
  basedUrl = environment.apiUrl + 'Favoured';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) {}

  addFavoured(model: any) {
    //model = JSON.stringify(model);
    return this.http.post(this.basedUrl, model, this.httpOptions);
  }
}
