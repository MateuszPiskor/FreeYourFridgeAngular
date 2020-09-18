import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../../_services/recipe.service';
import { AlertifyjsService } from '../../_services/alertifyjs.service';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';
import { RecipeToList } from 'src/app/_models/recipeToList';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css'],
})
export class RecipeListComponent implements OnInit {
  recipesToList: RecipeToList[];

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
      (recipesToList: RecipeToList[]) => {
        this.recipesToList = recipesToList;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
}
