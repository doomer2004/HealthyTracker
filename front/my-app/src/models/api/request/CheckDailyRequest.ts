import { APIRequestBase } from "./base/APIRequestBase";


export interface CheckDailyRequest extends APIRequestBase {
	date: string
}