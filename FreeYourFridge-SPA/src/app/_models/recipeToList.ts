import { MissedIngredients } from './missedIngredients';
import { UsedIngredients } from './usedIngredients';

export interface RecipeToList {
  id: number;
  title: string;
  image: string;
  missedIngredients: MissedIngredients[];
  usedIngredients: UsedIngredients[];
}
