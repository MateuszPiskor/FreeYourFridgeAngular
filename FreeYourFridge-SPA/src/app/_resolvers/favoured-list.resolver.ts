import {Injectable} from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { FavouredDto } from '../_models/Favoured/favouredDto';
import { FavouredService } from '../_services/favoured.service';
import { AlertifyjsService } from '../_services/alertifyjs.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class FavouredListResolver implements Resolve<FavouredDto[]> {

    pageNumber = 1;
    pageSize = 4;

    constructor(private favouredService: FavouredService,
                private router: Router,
                private alertify: AlertifyjsService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<FavouredDto[]> {
        return this.favouredService.getFavoureds(this.pageNumber, this.pageSize).pipe(
            catchError(error => {
                this.alertify.error('Problem z pobraniem danych');
                this.router.navigate(['']);
                return of(null);
            })
        );
    }
}
