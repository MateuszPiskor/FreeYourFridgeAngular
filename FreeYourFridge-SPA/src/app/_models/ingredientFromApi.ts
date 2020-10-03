import { Units } from './Units';

export interface IngredientFromApi {
  id: number;
  originalName: string;
  possibleUnits: Units[];

}
