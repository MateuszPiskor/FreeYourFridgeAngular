import { Component, OnInit } from '@angular/core';
import { RecipeService } from 'src/app/_services/recipe.service';
import { Instruction} from 'src/app/_models/instruction';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-recipe-instruction',
  templateUrl: './recipe-instruction.component.html',
  styleUrls: ['./recipe-instruction.component.scss']
})
export class RecipeInstructionComponent implements OnInit {

  constructor(private recipeSerivice: RecipeService, private route: ActivatedRoute) { }
  instruction: string[];
  ngOnInit() {
    this.loadInstruction();
  }
  loadInstruction() {
      this.recipeSerivice.getInstruction(+this.route.snapshot.params['id']).subscribe(data=>{
        this.instruction = data;
      })
  }

}
