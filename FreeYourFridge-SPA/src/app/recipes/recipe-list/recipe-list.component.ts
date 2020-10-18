import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../../_services/recipe.service';
import { AlertifyjsService } from '../../_services/alertifyjs.service';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';
import { RecipeToList } from 'src/app/_models/recipeToList';
import { JoiningService } from 'src/app/_services/joining.service';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css'],
})
export class RecipeListComponent implements OnInit {
  recipesToList: RecipeToList[];
  params: any;

  constructor(
    private recipeService: RecipeService,
    private alertify: AlertifyjsService,
    private route: ActivatedRoute,
    private joiningService: JoiningService
  ) {}

  ngOnInit() {
    this.joiningService.announced$.subscribe((params) => {
      this.params = params;
      if (this.params.dietType !== 'notSet' || this.params.cuisineType !== 'notSet' || this.params.mealType !== 'notSet'  ) {
        this.loadRecipes(this.params);
      } else {
        this.loadRecipes();
      }
    });
    this.loadRecipes();
  }

  loadRecipes(params?) {
    this.recipeService.getRecipes(params).subscribe(
      (recipesToList: RecipeToList[]) => {
        this.recipesToList = recipesToList;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
}
