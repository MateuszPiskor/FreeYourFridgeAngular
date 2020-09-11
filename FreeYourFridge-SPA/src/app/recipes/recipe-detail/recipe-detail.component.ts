import { Component, OnInit, Input } from '@angular/core';
import { RecipeToDetails } from '../../_models/recipeToDetails';
import { Nutritions } from '../../_models/recipeNutritions';
import { Instruction } from '../../_models/instruction';
import { MealDto } from '../../_models/mealDto';
import { RecipeIngredients } from '../../_models/ingredient';
import { RecipeService } from '../../_services/recipe.service';
import { AlertifyjsService } from '../../_services/alertifyjs.service';
import { ActivatedRoute } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { DealMealService } from 'src/app/_services/dealMeal.service';
import { Data } from "../../data";
import { RecipeToList } from 'src/app/_models/recipeToList';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.scss'],
})
export class RecipeDetailComponent implements OnInit {
  recipeToDetail: RecipeToDetails;
  nutritions: Nutritions;
  instructions: Instruction[];
  recipeIngredients: RecipeIngredients;
  slideHtml;
  recipeToList: RecipeToList;
  model: any = {};
  mealDto: MealDto;


  constructor(
    private recipeService: RecipeService,
    private alertify: AlertifyjsService,
    private route: ActivatedRoute,
    private dealMeal: DealMealService,
    private data: Data,
  ) {}

  ngOnInit() {
    this.loadRecipe();
    this.loadNutritions();
    this.loadInstruction();
    this.loadIngredient();
  }

  loadRecipe() {
    this.recipeService.getRecipe(+this.route.snapshot.params['id']).subscribe(
      (recipeToDetail: RecipeToDetails) => {
        this.recipeToDetail = recipeToDetail;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  loadNutritions() {
    this.recipeService.getNutrition(+this.route.snapshot.params['id']).subscribe(
      (nutritions: Nutritions) => {
        this.nutritions = nutritions;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  loadInstruction() {
    this.recipeService
      .getInstruction(+this.route.snapshot.params['id'])
      .subscribe(
        (instructions: Instruction[]) => {
          this.instructions = instructions;
        },
        (error) => {
          this.alertify.error(error);
        }
      );
  }

  loadIngredient() {
    this.recipeToList = this.data.storage;
    console.log(this.recipeToList);
  }

  addMeal(){
    this.mealDto.amount = this.model;
    this.mealDto.nutrition = this.nutritions;
    console.log(this.model);
    this.dealMeal.addMeal(this.mealDto).subscribe(() => {
      this.alertify.success('Meal added');
    }, error => {
      this.alertify.error('Some problem occur');
      // this.model.username = '';
      // this.model.password = '';
    });
    // this.route.navigate(['/home']);
    // this.model.username = '';
    // this.model.password = '';
  }
}
