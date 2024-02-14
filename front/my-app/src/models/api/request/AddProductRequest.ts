import { APIRequestBase } from "./base/APIRequestBase";

export interface AddProductRequest extends APIRequestBase {
	name: string;
   volume: number;
	mealId: string;
}

