
export interface User {
    email: string;
    username: string;
    gender: string;
    age: Date;
    weight: number;
    height: number;
    dailyDemand: number;
    carbohydrates: number;
    fats: number;
    protein: number;
    description: string;
    activityLevel: ActivityLevel;
    dailyDemandToRealize:number;
}

export enum ActivityLevel
{
  Low, Medium, High
}

