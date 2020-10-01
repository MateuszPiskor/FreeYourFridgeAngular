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
  instructions:Array<Instruction2>;
  ingredients:Array<UsedIngredients>;
}

export interface INutrition
{
  caloricbreakdown:ICaloribreakdown;
  nutrients:Array<INutrient>;
  weightPerServing:IWeightPerServing;
  properties:Array<IProperties>;
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

export interface IWeightPerServing
{
  amount:number;
  unit:string
}

export interface IProperties
{
  title:string;
  amount:number;
  unit:string;
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
}

export class DmFlat implements DailyMealFlat
{
  title: string;
  image: string;
  id: number;
  grams: number;
  readyInMinute: number;
  userRemarks: string;
  timeOfLastMeal: number;
  nutrients: INutrient[];
  caloricbreakdown: ICaloribreakdown;
  steps: Step[];

}

