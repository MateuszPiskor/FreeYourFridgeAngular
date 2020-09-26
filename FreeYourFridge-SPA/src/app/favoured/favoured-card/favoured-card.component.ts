import { Component, Input, OnInit } from '@angular/core';
import { FavouredDto } from 'src/app/_models/Favoured/favouredDto';
import { RecipeToDetails } from 'src/app/_models/recipeToDetails';

@Component({
  selector: 'app-favoured-card',
  templateUrl: './favoured-card.component.html',
  styleUrls: ['./favoured-card.component.scss']
})
export class FavouredCardComponent implements OnInit {

  @Input()
  favoured: FavouredDto;

  constructor() { }

  ngOnInit() {
  }

}
