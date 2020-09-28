import { IngredientDto } from './ingredientDto';
import {Deserializable} from './deserializable';
import { User } from './user';

export interface Fridge {
  id: number;
  userId: number;
  listIgredients: IngredientDto[];
  user: User;

  //deserialize(input: any): this {
  //  Object.assign(this, input);
  //  this.ListIgredients = input.ListIgredients.map(ingredient => new IngredientDto().deserialize(ingredient));
  //  return this;
  //}
}

