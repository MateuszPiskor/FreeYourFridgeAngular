import { DailyMealSimpleDto} from './dailyMealSimpleDto';
import { Nutritions} from './recipeNutritions';
import { Instruction} from './instruction';
import{UsedIngredients} from './usedIngredients';
import { Instructions, Steps } from './steps';

export class DailyMealDetailsDto extends DailyMealSimpleDto
{
  calories: number;
  carbs: number;
  fat: number;
  protein: number;
  readyInMinute: number;
  userRemarks:string;
  timeOfLastMeal:number;
  nutritions:Array<Nutritions>;
  instructions:Array<Instructions>;
  ingredients:Array<UsedIngredients>;
}
