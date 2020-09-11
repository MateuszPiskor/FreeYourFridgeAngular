import { Photo } from './photo';
import { MissedIngredients} from './missedIngredients';
import { UsedIngredients} from './usedIngredients';

export interface RecipeToDetails {
  id: number;
  title: string;
  image: string;
  readyInMinutes: number;
  spoonacularScore: number;
}
