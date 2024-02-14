import { APIRequestBase } from "./base/APIRequestBase";

export interface UpdateProductRequest extends APIRequestBase{
	productId: string
	volume: number
}