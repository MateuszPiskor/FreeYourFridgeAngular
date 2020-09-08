import { Component, OnInit, Input } from '@angular/core';
import { Recipe } from 'src/app/_models/recipe';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-recipe-card',
  templateUrl: './recipe-card.component.html',
  styleUrls: ['./recipe-card.component.scss'],
})
export class RecipeCardComponent implements OnInit {
  @Input() recipe: Recipe;
  constructor(private _route: ActivatedRoute, private _router: Router) {}

  private selectedRecipeId: number;

  ngOnInit() {
    this.selectedRecipeId = +this._route.snapshot.paramMap.get('id');
  }

  viewDetails(){
    "['/recipes/', recipe.id]"
    this._router.navigate(['/recipes/', this.recipe.id]);
  }
}
