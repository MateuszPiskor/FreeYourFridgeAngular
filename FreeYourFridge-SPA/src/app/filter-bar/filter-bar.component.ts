import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RecipeService } from '../_services/recipe.service';
import { FilterBarParams } from '../_models/filterBarParams';
import { JoiningService } from '../_services/joining.service';

@Component({
  selector: 'app-filter-bar',
  templateUrl: './filter-bar.component.html',
  styleUrls: ['./filter-bar.component.scss'],
})
export class FilterBarComponent implements OnInit {
  cuisineType: any;
  dietType: any;
  mealType: any;
  userParams: FilterBarParams = {
    dietType: 'notSet',
    cuisineType: 'notSet',
    mealType: 'noSet'
  };

  cuisines = [
    'select',
    'African',
    'American',
    'British',
    'Chinese',
    'Eastern European',
    'European',
    'French',
    'German',
    'Greek',
    'Indian',
    'Italian',
    'Japanese',
    'Latin American',
    'Mediterranean',
    'Mexican',
    'Thai',
    'Vietnamese',
  ];

  meals = [
    'main course',
    'side dish',
    'dessert',
    'appetizer',
    'salad',
    'bread',
    'breakfast',
    'soup',
    'beverage',
    'sauce',
    'marinade',
    'fingerfood',
    'snack',
    'drink',
  ];

  diets = ['Gluten Free', 'Vegetarian', 'Ketogenic', 'Lacto-Vegetarian', 'Ovo-Vegetarian', 'Vegan', 'Pescetarian','Paleo','Whole30'];

  constructor(
    private recipeService: RecipeService,
    private _router: Router,
    private joiningService: JoiningService
  ) {}

  ngOnInit() {}

  loadRecipes() {
    this.userParams.cuisineType = this.cuisineType;
    this.userParams.dietType = this.dietType;
    this.userParams.mealType = this.mealType;
    this.joiningService.announce(this.userParams);
  }

  clearOptions(){
  this.cuisineType = 'undefined';
  this.dietType = 'undefined';
  this.mealType = 'undefined';
  this.loadRecipes();
  }
}
