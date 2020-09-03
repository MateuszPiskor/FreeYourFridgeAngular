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
  cheap: boolean;
  widget: string;
  calories: number;
  photos?: Photo[];
  carbs: string;
  fat: string;
  protein: string;
  missedIngredients: MissedIngredients[];
  usedIngredients: UsedIngredients[];
}
