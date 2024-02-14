import { AddProductRequest } from "../../models/api/request/AddProductRequest";
import { UpdateProductRequest } from "../../models/api/request/UpdateProductRequest";
import { DeleteProductRequest } from "../../models/api/request/base/DeleteProductRequest";

import { AddProductResponse, DeleteProductResponse } from "../../models/api/response/AddProductResponse";
import { UpdateProductResponse } from "../../models/api/response/UpdateProductResponse";
import API from "./repository/API";

const Products = {
	addToMeal: async (requestBody: AddProductRequest)  => {
		try {
			return await API.post<AddProductRequest, AddProductResponse>('/product', requestBody);
		}
		catch (e) {
			console.error()
		}
	},

	deleteProduct: async (requestBody: {productId: string}) => {
		try {
			return await API.delete<DeleteProductRequest>(`/product?productId=${requestBody.productId}`);
		}
		catch (e) {
			console.error()
		}

	},

	updateProduct: async (requestBody: UpdateProductRequest) => {
		try {
			return await API.put<UpdateProductRequest, UpdateProductResponse>(`/product?productId=${requestBody.productId}&volume=${requestBody.volume}`, requestBody);
		}
		catch (e) {
			console.error()
		}
	}

}


export default Products