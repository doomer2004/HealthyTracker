import { APIRequestBase } from "./base/APIRequestBase";

export interface SaveNutritionRequest extends APIRequestBase {
	userId: string
	calories: number
	carbs: number
	fat : number
	proteins: number
}

export interface GetNutritionRequest extends APIRequestBase {
	userId: string
	time : string
	calories: number
	carbs: number
	fat : number
	proteins: number
}
