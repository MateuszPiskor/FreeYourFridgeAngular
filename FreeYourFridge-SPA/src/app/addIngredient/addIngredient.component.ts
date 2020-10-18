import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { debounceTime, distinctUntilChanged, startWith, switchMap } from 'rxjs/operators';
import { IngredientFromApi } from '../_models/ingredientFromApi';
import { Units } from '../_models/Units';
import { AlertifyjsService } from '../_services/alertifyjs.service';
import { AuthService } from '../_services/auth.service';
import { FridgeService } from '../_services/fridge.service';
import { IngredientToApi} from '../_models/ingredientToApi';
import { ListOfIngredients } from '../_models/listOfIngredients';
import { selectedIndices } from '@progress/kendo-angular-dropdowns/dist/es2015/util';

@Component({
  selector: 'app-addIngredient',
  templateUrl: './addIngredient.component.html',
  styleUrls: ['./addIngredient.component.scss']
})
export class AddIngredientComponent implements OnInit {
  public listOfIngredients: ListOfIngredients;
  public sortlistOfIngredients: ListOfIngredients;
  public ingredientFromApi: IngredientFromApi;
  public ingredientId: number;
  public SelIngredientName = 0;
  units: Units[] = [];
  public ingredientToApi: IngredientToApi = {
    id: 0,
    Name: '',
    amount: 0,
    unit: 'g'
  };
  constructor(private route: ActivatedRoute, private alertify: AlertifyjsService, private fridgeService: FridgeService, private authService: AuthService, private router: Router) {

   }
  FillUnits(){
    this.ingredientId = Number(this.SelIngredientName);
    this.fridgeService.getUnitsFromApi(this.ingredientId).subscribe(data => {
    this.ingredientFromApi = data;
    this.units = this.ingredientFromApi.possibleUnits;
    });
  }

  ngOnInit() {
    this.route.data.subscribe(data =>{
      this.listOfIngredients = data['ingredient'];
      this.listOfIngredients.sort(function(a,b){
        return a.originalName.localeCompare(b.originalName);
      });
    });
  }

  addIngredient(){
    this.ingredientToApi.id = this.SelIngredientName;
    this.ingredientToApi.Name = this.ingredientFromApi.originalName;
    this.fridgeService.addNewIngredient(this.authService.decodedToken.nameid, this.ingredientToApi).subscribe(next => {
      this.alertify.success('Ingredient add succesfully');
    }, error => {
      this.alertify.error(error);
    });
    window.location.reload();
  }
  cancel(){
    this.router.navigateByUrl('fridge');
  }

}
