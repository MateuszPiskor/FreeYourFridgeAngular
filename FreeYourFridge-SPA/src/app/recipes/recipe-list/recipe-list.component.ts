import { Component, OnInit } from '@angular/core';
import { Recipe } from '../../_models/recipe';
import { RecipeService } from '../../_services/recipe.service';
import { AlertifyjsService } from '../../_services/alertifyjs.service';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css'],
})
export class RecipeListComponent implements OnInit {
  recipes: Recipe[];

  constructor(
    private recipeService: RecipeService,
    private alertify: AlertifyjsService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.loadRecipes();
  }

  loadRecipes() {
    this.recipeService.getRecipes().subscribe(
      (recipes: Recipe[]) => {
        this.recipes = recipes;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
}
