import { UsedIngredients } from './usedIngredients';
import { MissedIngredients } from './missedIngredients';

export interface RecipeIngredients {
  name: string;
  usedingredientDto: UsedIngredients[];
  missedingredientDto: MissedIngredients[];
}
