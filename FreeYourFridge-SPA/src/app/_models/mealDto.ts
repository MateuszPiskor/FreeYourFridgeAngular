import { Photo } from './photo';
import { MissedIngredients} from './missedIngredients';
import { UsedIngredients} from './usedIngredients';
import { Nutritions } from './recipeNutritions';

export interface MealDto
 {
  id: number;
  amount: number;
  title: string;
  photoUrl: string;
  instructions: string;
  summary: string;
  readyInMinutes: number;
  spoonacularScore: number;
  score: number;
  photos?: Photo[];
  missedIngredients: MissedIngredients[];
  usedIngredients: UsedIngredients[];
  nutrition: Nutritions;
}
