import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FavouredDto } from '../_models/Favoured/favouredDto';
import { PaginationResult } from '../_models/pagination';
import { map } from 'rxjs/operators';

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

  getFavoureds(
    page?,
    itemsPerPage?
  ): Observable<PaginationResult<FavouredDto[]>> {
    const paginationResult: PaginationResult<
      FavouredDto[]
    > = new PaginationResult<FavouredDto[]>();
    let params = new HttpParams();
    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    return this.http
      .get<FavouredDto[]>(this.basedUrl, { observe: 'response', params })
      .pipe(
        map((response) => {
          paginationResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginationResult.pagination = JSON.parse(
              response.headers.get('Pagination')
            );
          }
          return paginationResult;
        })
      );
  }

  remove(favoured: FavouredDto) {
    return this.http.delete(this.basedUrl + '/' + favoured.spoonacularId);
  }

  editScore(favouredId: number, favouredScore: number) {
    return this.http.put(this.basedUrl + '/' + favouredId, favouredScore);
  }
}
