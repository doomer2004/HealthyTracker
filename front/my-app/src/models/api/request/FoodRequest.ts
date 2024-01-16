import { APIRequestBase } from "./base/APIRequestBase";

export interface AddFoodRequest extends APIRequestBase {
	userId ?: string
	meal ?: string
	date ?: string
	name ?: string
	value ?: number
}

export interface ChangeFoodRequest extends APIRequestBase {
	userId ?: string
	meal ?: string
	date ?: string
	name ?: string
	value ?: number
}