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

@Component({
  selector: 'app-addIngredient',
  templateUrl: './addIngredient.component.html',
  styleUrls: ['./addIngredient.component.scss']
})
export class AddIngredientComponent implements OnInit {
  public listOfIngredients: ListOfIngredients;
  public ingredientFromApi: IngredientFromApi;
  public ingredient: IngredientFromApi;
  SelIngredientName: string = "";
  units: Units[] = [];
  public ingredientToApi: IngredientToApi = {
    id: 0,
    originalName: '',
    amount: 0,
    unit: 'g'
  };
  constructor(private route: ActivatedRoute, private alertify: AlertifyjsService, private fridgeService: FridgeService, private authService: AuthService, private router: Router) {

   }
  FillUnits(){
    this.ingredient = this.ingredientFromApi[this.SelIngredientName];
    console.log(this.ingredient.originalName);
    this.fridgeService.getUnitsFromApi(this.ingredient.id).subscribe(data => {
      this.ingredientFromApi = data['ingredientUnits'];
    });
  }

  ngOnInit() {
    this.route.data.subscribe(data =>{
      this.listOfIngredients = data['ingredient'];
    });
  }

  addIngredient(){

    this.fridgeService.addNewIngredient(this.authService.decodedToken.nameid, this.ingredientToApi);
  }

}
