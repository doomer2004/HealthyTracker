import { APIRequestBase } from "./APIRequestBase";

export interface DeleteProductRequest extends APIRequestBase {
	productId: string;
}