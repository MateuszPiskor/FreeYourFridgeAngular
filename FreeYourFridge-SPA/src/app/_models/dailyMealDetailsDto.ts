import { DailyMealSimpleDto} from './dailyMealSimpleDto';
import { Nutritions} from './recipeNutritions';
import { Instruction} from './instruction';
import{UsedIngredients} from './usedIngredients';
import { Instruction2, Step } from './steps';

export class DailyMealDetailsDto
{
  title:string
  image: string;
  id: number;
  grams: number;
  readyInMinute: number;
  userRemarks:string;
  timeOfLastMeal:number;
  nutrition:INutrition;
  // nutritions:Array<Nutritions>;
  instructions:Array<Instruction2>;
  ingredients:Array<UsedIngredients>;
}

export interface INutrition
{
  caloricbreakdown:ICaloribreakdown;
  nutrients:Array<INutrient>;
}

export interface ICaloribreakdown
{
  percentProtein:number;
  percentFat:number;
  percentCarbs:number;
}

export interface INutrient
{
  title:string;
  amount:number;
  unit: string;
  percentOfDailyNeeds:number;
}


export interface DailyMealFlat
{
  title:string
  image: string;
  id: number;
  grams: number;
  readyInMinute: number;
  userRemarks:string;
  timeOfLastMeal:number;
  nutrients:Array<INutrient>;
  caloricbreakdown:ICaloribreakdown;
  steps:Array<Step>

  // instructions:Array<Instructions>;
  // ingredients:Array<UsedIngredients>;
}
