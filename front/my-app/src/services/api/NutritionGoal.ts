import Nutrition from "../../models/Goal";
import { SaveNutritionRequest } from "../../models/api/request/NutritionRequest";
import { NutritionResponse } from "../../models/api/response/NutritionResponse";
import { ErrorModel } from "../../models/api/response/base/ErrorModel";
import API from "./repository/API";

type AddNutritionGoalBody = {
	userId: string;
    calories: number;
    proteins: number;
    fat: number;
    carbohydrates: number;
}

const NutritionGoal = {
	saveNutrition: async (requestBody : AddNutritionGoalBody)  => {
		try {
			return await API.post<AddNutritionGoalBody, Nutrition>('/nutrition-goal', requestBody);
		}
		catch (e) {
			console.error()
		}
	},

}


export default NutritionGoal