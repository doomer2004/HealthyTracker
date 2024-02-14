import { ListDailyMealsRequest } from "../../models/api/request/ListDailyMealsRequest";
import { ListDailyMealsResponse } from "../../models/api/response/ListDailyMealsResponse";
import API from "./repository/API";

const Meal = {
	listByDay: async ({ date }: { date: string }) => {
		try {
			return await API.post<ListDailyMealsRequest, ListDailyMealsResponse>(`/daily/daily?date=${date}`, {});
		}
		catch (e) {
			console.error()
		}
	},

}


export default Meal