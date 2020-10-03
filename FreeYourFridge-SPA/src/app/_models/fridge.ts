import { IngredientDto } from './ingredientDto';
import { User } from './user';

export interface Fridge {
  id: number;
  userId: number;
  listIgredients: IngredientDto[];
  user: User;

}

