import Meal from "../../meal/Meal";
import { APIResponseBase } from "./base/APIResponseBase";

export interface ListDailyMealsResponse extends APIResponseBase {
	date: string;
	normIsFulfilled: boolean;
	meals: Meal[]
}