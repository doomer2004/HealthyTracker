import { CheckDailyRequest } from "../../models/api/request/CheckDailyRequest";
import { CheckDailyResponse } from "../../models/api/response/CheckDailyResponse";
import API from "./repository/API";

const Daily = {
	checkDaily : async (requestBody: CheckDailyRequest) => {
		try {
			return await API.get<boolean>(`/daily/check-daily?date=${requestBody.date}`);	
		}
		catch (e) {
			console.error()
		}
	}
}
export default Daily;