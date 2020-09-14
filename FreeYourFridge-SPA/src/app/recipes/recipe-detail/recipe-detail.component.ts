import { Component, OnInit, Input } from '@angular/core';
import { RecipeToDetails } from '../../_models/recipeToDetails';
import { Nutritions } from '../../_models/recipeNutritions';
import { Instruction } from '../../_models/instruction';
import { MealDto } from '../../_models/mealDto';
import { IngredientDto } from '../../_models/ingredientDto';
import { RecipeIngredients } from '../../_models/ingredient';
import { RecipeService } from '../../_services/recipe.service';
import { AlertifyjsService } from '../../_services/alertifyjs.service';
import { ActivatedRoute } from '@angular/router';
import { DealMealService } from 'src/app/_services/dealMeal.service';
import { Data } from '../../data';
import { RecipeToList } from 'src/app/_models/recipeToList';
import { Router } from '@angular/router';
import { ShoppingListService } from 'src/app/_services/shoppingList.service';

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
    private shoppingList: ShoppingListService,
    private data: Data,
    private routeDirection: Router
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
    this.recipeService
      .getNutrition(+this.route.snapshot.params['id'])
      .subscribe(
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

  addMeal(meal) {
    const mealDto = new MealDto();
    mealDto.Grams = +meal.grams;
    mealDto.spoonacularId = +meal.spoonacularId;
    this.dealMeal.addMeal(mealDto).subscribe(
      () => {
        this.alertify.success('Meal added');
      },
      (error) => {
        this.alertify.error('Some problem occur');
        this.model.username = '';
        this.model.password = '';
      }
    );
    this.routeDirection.navigate(['/dailyMeal']);
  }

  addIngredientToShoppingList(ingredient) {
    const ingredientDto = new IngredientDto();
    ingredientDto.spoonacularId = +ingredient.spoonacularId;
    ingredientDto.amount = +ingredient.amount;
    ingredientDto.name = ingredient.name;
    ingredientDto.unit = ingredient.unit;

    this.shoppingList.addIngredient(ingredientDto).subscribe(
      () => {
        this.alertify.success('Added to shoplist');
      },
      (error) => {
        this.alertify.error('Some problem occur');
      }
    );
    // this.routeDirection.navigate(['/dailyMeal']);
  }
}
