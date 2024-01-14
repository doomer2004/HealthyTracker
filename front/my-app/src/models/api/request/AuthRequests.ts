import { APIRequestBase } from "./base/APIRequestBase";

export interface SignUpRequest extends APIRequestBase {
	firstName: string;
	lastName: string;
	email: string;
	password: string;
}

export interface SignInRequest extends APIRequestBase {
	email: string;
	password: string;
}

export interface ConfirmEmailRequest extends APIRequestBase { 
	userId: string;
	url: string;
}

export interface RefreshTokenRequest extends APIRequestBase {
	refreshToken: string;
	accessToken: string;
}

export { }
