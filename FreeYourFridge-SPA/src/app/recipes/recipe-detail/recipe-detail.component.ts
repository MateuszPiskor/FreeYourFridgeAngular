import { Component, OnInit, Input } from '@angular/core';
import { Recipe } from '../../_models/recipe';
import { Instruction } from '../../_models/instruction';
import { Ingredient } from '../../_models/ingredient';
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
  widget: string;
  data: string;
  instructions: Instruction[];
  ingredient: Ingredient[];
  slideHtml;
  @Input()
  recipes;

  constructor(
    private recipeService: RecipeService,
    private alertify: AlertifyjsService,
    private route: ActivatedRoute,
    private sanitizer: DomSanitizer,
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.loadRecipe();
    this.loadInstruction();
    //this.loadIngredient();
  }

  loadRecipe() {
    this.recipeService.getRecipe(+this.route.snapshot.params['id']).subscribe(
      (recipe: Recipe) => {
        this.recipe = recipe;
        this.loadWidget();
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  loadWidget() {
    this.http
      .get('https://api.spoonacular.com/recipes/749013/ingredientWidget?', {
        responseType: 'text',
      })
      .subscribe((res) => {
        this.slideHtml = this.sanitizer.bypassSecurityTrustHtml(res);
        console.log(this.slideHtml);
      });
  }
  justTest() {
    console.log('just test');
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
  // loadIngredient() {
  //   this.recipeService.getIngredients(+this.route.snapshot.params['id']).subscribe(
  //     (ingredient: Ingredient[]) => {
  //       this.ingredient = ingredient;
  //     },
  //     (error) => {
  //       this.alertify.error(error);
  //     }
  //   );
  // }
}
