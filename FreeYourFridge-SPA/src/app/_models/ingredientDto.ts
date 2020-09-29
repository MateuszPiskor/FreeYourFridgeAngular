import {Deserializable} from './deserializable';

export interface IngredientDto  {
  id: number;
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
