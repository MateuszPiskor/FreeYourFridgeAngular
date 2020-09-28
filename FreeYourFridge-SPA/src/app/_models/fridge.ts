import { IngredientDto } from './ingredientDto';
import {Deserializable} from './deserializable';

export interface Fridge {
  id: number;
  userId: number;
  Igredients?: IngredientDto[];

  //deserialize(input: any): this {
  //  Object.assign(this, input);
  //  this.ListIgredients = input.ListIgredients.map(ingredient => new IngredientDto().deserialize(ingredient));
  //  return this;
  //}
}

