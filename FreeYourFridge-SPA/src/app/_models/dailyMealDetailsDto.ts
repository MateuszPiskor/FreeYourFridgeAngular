import { DailyMealSimpleDto} from './dailyMealSimpleDto';
import { Nutritions} from './recipeNutritions';
import { Instruction} from './instruction';
import{UsedIngredients} from './usedIngredients';

export class DailyMealDetailsDto extends DailyMealSimpleDto
{
  calories: number;
  carbs: string;
  fat: string;
  protein: string;
  readyInMinute: number;
  // userRemarks:string;
  nutritions:Array<Nutritions>;
  instructions:Array<Instruction>;
  ingredients:Array<UsedIngredients>;
}
