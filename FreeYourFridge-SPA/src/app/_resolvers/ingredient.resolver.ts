import {Injectable} from '@angular/core';
import {Resolve, Router, ActivatedRouteSnapshot, ActivatedRoute} from '@angular/router';
import {AlertifyjsService} from '../_services/alertifyjs.service';
import {Observable, of} from 'rxjs';
import {catchError} from 'rxjs/operators';
import {AuthService} from '../_services/auth.service';
import {FridgeService} from '../_services/fridge.service';
import { IngredientFromApi } from '../_models/ingredientFromApi';

@Injectable()
export class IngredientResolver implements Resolve<IngredientFromApi>{
    // tslint:disable-next-line: max-line-length
    constructor(private fridgeService: FridgeService, private authService: AuthService, private router: Router, private alertify: AlertifyjsService) {}
        resolve(router: ActivatedRouteSnapshot): Observable<IngredientFromApi>{
            return this.fridgeService.getIngredientFromApi().pipe(
                catchError(error => {
                    this.alertify.error('Problem retrieving your data');
                    this.router.navigate(['/fridge']);
                    return of(null);
                })
            );
        }
}
