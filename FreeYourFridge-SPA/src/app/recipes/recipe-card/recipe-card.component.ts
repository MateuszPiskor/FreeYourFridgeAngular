import { Component, OnInit, Input } from '@angular/core';
import { RecipeToList } from 'src/app/_models/recipeToList';
import { ActivatedRoute, Router } from '@angular/router';
import { Data } from "../../data";

@Component({
  selector: 'app-recipe-card',
  templateUrl: './recipe-card.component.html',
  styleUrls: ['./recipe-card.component.scss'],
})
export class RecipeCardComponent implements OnInit {
  @Input() recipeToList: RecipeToList;
  constructor(private _route: ActivatedRoute, private _router: Router, private data: Data) {}

  private selectedRecipeId: number;

  ngOnInit() {
    this.selectedRecipeId = +this._route.snapshot.paramMap.get('id');
  }

  viewDetails(){
    this.data.storage = this.recipeToList;
    "['/recipes/', recipe.id]"
    this._router.navigate(['/recipes/', this.recipeToList.id]);
  }
}


