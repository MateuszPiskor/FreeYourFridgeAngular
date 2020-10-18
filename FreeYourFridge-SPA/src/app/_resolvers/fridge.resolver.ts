import {Injectable} from '@angular/core';
import {Fridge} from '../_models/fridge';
import {Resolve, Router, ActivatedRouteSnapshot, ActivatedRoute} from '@angular/router';
import {AlertifyjsService} from '../_services/alertifyjs.service';
import {Observable, of} from 'rxjs';
import {catchError} from 'rxjs/operators';
import {AuthService} from '../_services/auth.service';
import {FridgeService} from '../_services/fridge.service';

@Injectable()
export class FridgeResolver implements Resolve<Fridge>{
    // tslint:disable-next-line: max-line-length
    constructor(private fridgeService: FridgeService, private authService: AuthService, private router: Router, private alertify: AlertifyjsService) {}
        resolve(router: ActivatedRouteSnapshot): Observable<Fridge>{
            return this.fridgeService.getUserFridge(this.authService.decodedToken.nameid).pipe(
                catchError(error => {
                    this.alertify.error('Problem retrieving your data');
                    this.router.navigate(['/members']);
                    return of(null);
                })
            );
        }
}
