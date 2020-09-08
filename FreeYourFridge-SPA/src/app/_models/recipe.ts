import { Photo } from './photo';
import { MissedIngredients} from './missedIngredients';
import { UsedIngredients} from './usedIngredients';

export interface Recipe {
  id: number;
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
}
