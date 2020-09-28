import {Deserializable} from './deserializable';

export interface IngredientDto  {
  spoonacularId: number;
  amount: number;
  name: string;
  unit: string;
  fridgeId: number;

  //deserialize(input: any) {
  //  Object.assign(this, input);
  //  return this;
 //}

}
