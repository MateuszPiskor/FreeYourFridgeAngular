import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ToDoItem } from '../_models/toDoItem';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token'),
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root',
})
export class ShoppingListService {
  basedUrl = environment.apiUrl + 'shoppingList';

  getToDoItems(): Observable<ToDoItem[]> {
    return this.http.get<ToDoItem[]>(this.basedUrl, httpOptions);
  }

  constructor(private http: HttpClient) {}

  addToDoItem(model: any): Observable<ToDoItem> {
    return this.http.post<ToDoItem>(this.basedUrl, model);
  }

  deleteToDoItems(id: number): Observable<ToDoItem> {
    return this.http.delete<ToDoItem>(this.basedUrl + '/' + id);
  }
}
