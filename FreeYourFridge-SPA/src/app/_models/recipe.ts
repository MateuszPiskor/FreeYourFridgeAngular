import { Photo } from './photo';

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
  photos?: Photo[];
}

