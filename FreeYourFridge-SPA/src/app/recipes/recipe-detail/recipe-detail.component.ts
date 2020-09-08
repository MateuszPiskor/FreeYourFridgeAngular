import { Component, OnInit, Input } from '@angular/core';
import { Recipe } from '../../_models/recipe';
import { Nutritions } from '../../_models/recipeNutritions';
import { Instruction } from '../../_models/instruction';
import { RecipeIngredients } from '../../_models/ingredient';
import { RecipeService } from '../../_services/recipe.service';
import { AlertifyjsService } from '../../_services/alertifyjs.service';
import { ActivatedRoute } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.scss'],
})
export class RecipeDetailComponent implements OnInit {
  recipe: Recipe;
  nutritions: Nutritions;
  data: string;
  instructions: Instruction[];
  recipeIngredients: RecipeIngredients;
  slideHtml;
  recipes: Recipe[];
  // @Input()
  // recipes;

  constructor(
    private recipeService: RecipeService,
    private alertify: AlertifyjsService,
    private route: ActivatedRoute,
    private sanitizer: DomSanitizer,
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.loadRecipe();
    this.loadNutritions();
    this.loadInstruction();
    this.loadIngredient();
  }


  loadRecipe() {
    this.recipeService.getRecipe(+this.route.snapshot.params['id']).subscribe(
      (recipe: Recipe) => {
        this.recipe = recipe;
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
    this.recipeService.getIngredients(+this.route.snapshot.params['id']).subscribe(
      (recipeIngredients: RecipeIngredients) => {
        this.recipeIngredients = recipeIngredients;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
}
