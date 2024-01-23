//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming

import axios, { AxiosError, AxiosInstance, AxiosRequestConfig, AxiosResponse, CancelToken } from 'axios';

export class Client {
  private instance: AxiosInstance;
  private baseUrl: string;
  protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

  constructor(baseUrl?: string, instance?: any) {

    this.instance = instance ? instance : axios.create();

    this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";

  }

  /**
   * @param body (optional)
   * @return Success
   */
  signUp(body: SignUpDTO | undefined , cancelToken?: CancelToken | undefined): Promise<ErrorDtoSignUpResponseDtoEitherData[]> {
    let url_ = this.baseUrl + "/api/auth/sign-up";
    url_ = url_.replace(/[?&]$/, "");

    const content_ = JSON.stringify(body);

    let options_: AxiosRequestConfig = {
      data: content_,
      method: "POST",
      url: url_,
      headers: {
        "Content-Type": "application/json",
        "Accept": "text/plain"
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processSignUp(_response);
    });
  }

  protected processSignUp(response: AxiosResponse): Promise<ErrorDtoSignUpResponseDtoEitherData[]> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 200) {
      const _responseText = response.data;
      let result200: any = null;
      let resultData200  = _responseText;
      result200 = JSON.parse(resultData200);
      return Promise.resolve<ErrorDtoSignUpResponseDtoEitherData[]>(result200);

    } else if (status === 400) {
      const _responseText = response.data;
      let result400: any = null;
      let resultData400  = _responseText;
      result400 = JSON.parse(resultData400);
      return throwException("Bad Request", status, _responseText, _headers, result400);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<ErrorDtoSignUpResponseDtoEitherData[]>(null as any);
  }

  /**
   * @return Success
   */
  me(  cancelToken?: CancelToken | undefined): Promise<string> {
    let url_ = this.baseUrl + "/api/auth/me";
    url_ = url_.replace(/[?&]$/, "");

    let options_: AxiosRequestConfig = {
      method: "POST",
      url: url_,
      headers: {
        "Accept": "text/plain"
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processMe(_response);
    });
  }

  protected processMe(response: AxiosResponse): Promise<string> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 200) {
      const _responseText = response.data;
      let result200: any = null;
      let resultData200  = _responseText;
      result200 = JSON.parse(resultData200);
      return Promise.resolve<string>(result200);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<string>(null as any);
  }

  /**
   * @param body (optional)
   * @return Success
   */
  confirmEmail(body: ConfirmEmailDTO | undefined , cancelToken?: CancelToken | undefined): Promise<ErrorDtoAuthSuccessDTOEitherData[]> {
    let url_ = this.baseUrl + "/api/auth/confirm-email";
    url_ = url_.replace(/[?&]$/, "");

    const content_ = JSON.stringify(body);

    let options_: AxiosRequestConfig = {
      data: content_,
      method: "POST",
      url: url_,
      headers: {
        "Content-Type": "application/json",
        "Accept": "text/plain"
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processConfirmEmail(_response);
    });
  }

  protected processConfirmEmail(response: AxiosResponse): Promise<ErrorDtoAuthSuccessDTOEitherData[]> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 400) {
      const _responseText = response.data;
      let result400: any = null;
      let resultData400  = _responseText;
      result400 = JSON.parse(resultData400);
      return throwException("Bad Request", status, _responseText, _headers, result400);

    } else if (status === 200) {
      const _responseText = response.data;
      let result200: any = null;
      let resultData200  = _responseText;
      result200 = JSON.parse(resultData200);
      return Promise.resolve<ErrorDtoAuthSuccessDTOEitherData[]>(result200);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<ErrorDtoAuthSuccessDTOEitherData[]>(null as any);
  }

  /**
   * @param body (optional)
   * @return Success
   */
  signIn(body: SignInDTO | undefined , cancelToken?: CancelToken | undefined): Promise<ErrorDtoAuthSuccessDTOEitherData[]> {
    let url_ = this.baseUrl + "/api/auth/sign-in";
    url_ = url_.replace(/[?&]$/, "");

    const content_ = JSON.stringify(body);

    let options_: AxiosRequestConfig = {
      data: content_,
      method: "POST",
      url: url_,
      headers: {
        "Content-Type": "application/json",
        "Accept": "text/plain"
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processSignIn(_response);
    });
  }

  protected processSignIn(response: AxiosResponse): Promise<ErrorDtoAuthSuccessDTOEitherData[]> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 200) {
      const _responseText = response.data;
      console.log(_responseText);
      let result200: any = null;
      let resultData200  = _responseText;
      result200 = resultData200;
      return Promise.resolve<ErrorDtoAuthSuccessDTOEitherData[]>(result200);

    } else if (status === 400) {
      const _responseText = response.data;
      let result400: any = null;
      let resultData400  = _responseText;
      result400 = JSON.parse(resultData400);
      return throwException("Bad Request", status, _responseText, _headers, result400);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<ErrorDtoAuthSuccessDTOEitherData[]>(null as any);
  }

  /**
   * @param body (optional)
   * @return Success
   */
  refreshToken(body: RefreshTokenDTO | undefined , cancelToken?: CancelToken | undefined): Promise<ErrorDtoAuthSuccessDTOEitherData[]> {
    let url_ = this.baseUrl + "/api/auth/refresh-token";
    url_ = url_.replace(/[?&]$/, "");

    const content_ = JSON.stringify(body);

    let options_: AxiosRequestConfig = {
      data: content_,
      method: "POST",
      url: url_,
      headers: {
        "Content-Type": "application/json",
        "Accept": "text/plain"
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processRefreshToken(_response);
    });
  }

  protected processRefreshToken(response: AxiosResponse): Promise<ErrorDtoAuthSuccessDTOEitherData[]> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 200) {
      const _responseText = response.data;
      let result200: any = null;
      let resultData200  = _responseText;
      result200 = JSON.parse(resultData200);
      return Promise.resolve<ErrorDtoAuthSuccessDTOEitherData[]>(result200);

    } else if (status === 400) {
      const _responseText = response.data;
      let result400: any = null;
      let resultData400  = _responseText;
      result400 = JSON.parse(resultData400);
      return throwException("Bad Request", status, _responseText, _headers, result400);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<ErrorDtoAuthSuccessDTOEitherData[]>(null as any);
  }

  /**
   * @param body (optional)
   * @return Success
   */
  resendConfirmationCode(body: ResendConfirmationUrlDTO | undefined , cancelToken?: CancelToken | undefined): Promise<ErrorDtoAuthSuccessDTOEitherData[]> {
    let url_ = this.baseUrl + "/api/auth/resend-confirmation-code";
    url_ = url_.replace(/[?&]$/, "");

    const content_ = JSON.stringify(body);

    let options_: AxiosRequestConfig = {
      data: content_,
      method: "POST",
      url: url_,
      headers: {
        "Content-Type": "application/json",
        "Accept": "text/plain"
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processResendConfirmationCode(_response);
    });
  }

  protected processResendConfirmationCode(response: AxiosResponse): Promise<ErrorDtoAuthSuccessDTOEitherData[]> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 400) {
      const _responseText = response.data;
      let result400: any = null;
      let resultData400  = _responseText;
      result400 = JSON.parse(resultData400);
      return throwException("Bad Request", status, _responseText, _headers, result400);

    } else if (status === 200) {
      const _responseText = response.data;
      let result200: any = null;
      let resultData200  = _responseText;
      result200 = JSON.parse(resultData200);
      return Promise.resolve<ErrorDtoAuthSuccessDTOEitherData[]>(result200);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<ErrorDtoAuthSuccessDTOEitherData[]>(null as any);
  }

  /**
   * @param body (optional)
   * @return Success
   */
  forgotPassword(body: ForgotPasswordDTO | undefined , cancelToken?: CancelToken | undefined): Promise<ErrorDto[]> {
    let url_ = this.baseUrl + "/api/auth/forgot-password";
    url_ = url_.replace(/[?&]$/, "");

    const content_ = JSON.stringify(body);

    let options_: AxiosRequestConfig = {
      data: content_,
      method: "POST",
      url: url_,
      headers: {
        "Content-Type": "application/json",
        "Accept": "text/plain"
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processForgotPassword(_response);
    });
  }

  protected processForgotPassword(response: AxiosResponse): Promise<ErrorDto[]> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 400) {
      const _responseText = response.data;
      let result400: any = null;
      let resultData400  = _responseText;
      result400 = JSON.parse(resultData400);
      return throwException("Bad Request", status, _responseText, _headers, result400);

    } else if (status === 200) {
      const _responseText = response.data;
      let result200: any = null;
      let resultData200  = _responseText;
      result200 = JSON.parse(resultData200);
      return Promise.resolve<ErrorDto[]>(result200);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<ErrorDto[]>(null as any);
  }

  /**
   * @param body (optional)
   * @return Success
   */
  resetPassword(body: ResetPasswordDTO | undefined , cancelToken?: CancelToken | undefined): Promise<ErrorDto[]> {
    let url_ = this.baseUrl + "/api/auth/reset-password";
    url_ = url_.replace(/[?&]$/, "");

    const content_ = JSON.stringify(body);

    let options_: AxiosRequestConfig = {
      data: content_,
      method: "POST",
      url: url_,
      headers: {
        "Content-Type": "application/json",
        "Accept": "text/plain"
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processResetPassword(_response);
    });
  }

  protected processResetPassword(response: AxiosResponse): Promise<ErrorDto[]> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 400) {
      const _responseText = response.data;
      let result400: any = null;
      let resultData400  = _responseText;
      result400 = JSON.parse(resultData400);
      return throwException("Bad Request", status, _responseText, _headers, result400);

    } else if (status === 200) {
      const _responseText = response.data;
      let result200: any = null;
      let resultData200  = _responseText;
      result200 = JSON.parse(resultData200);
      return Promise.resolve<ErrorDto[]>(result200);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<ErrorDto[]>(null as any);
  }

  /**
   * @return Success
   */
  checkDaily(  cancelToken?: CancelToken | undefined): Promise<void> {
    let url_ = this.baseUrl + "/api/daily/check-daily";
    url_ = url_.replace(/[?&]$/, "");

    let options_: AxiosRequestConfig = {
      method: "GET",
      url: url_,
      headers: {
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processCheckDaily(_response);
    });
  }

  protected processCheckDaily(response: AxiosResponse): Promise<void> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 200) {
      const _responseText = response.data;
      return Promise.resolve<void>(null as any);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<void>(null as any);
  }

  /**
   * @param authorization_Code (optional)
   * @return Success
   */
  signUp2(authorization_Code: string | undefined , cancelToken?: CancelToken | undefined): Promise<ErrorDtoAuthSuccessDTOEitherData[]> {
    let url_ = this.baseUrl + "/api/google-auth/sign-up";
    url_ = url_.replace(/[?&]$/, "");

    let options_: AxiosRequestConfig = {
      method: "POST",
      url: url_,
      headers: {
        "Authorization-Code": authorization_Code !== undefined && authorization_Code !== null ? "" + authorization_Code : "",
        "Accept": "text/plain"
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processSignUp2(_response);
    });
  }

  protected processSignUp2(response: AxiosResponse): Promise<ErrorDtoAuthSuccessDTOEitherData[]> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 200) {
      const _responseText = response.data;
      let result200: any = null;
      let resultData200  = _responseText;
      result200 = JSON.parse(resultData200);
      return Promise.resolve<ErrorDtoAuthSuccessDTOEitherData[]>(result200);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<ErrorDtoAuthSuccessDTOEitherData[]>(null as any);
  }

  /**
   * @param authorization_Code (optional)
   * @return Success
   */
  signIn2(authorization_Code: string | undefined , cancelToken?: CancelToken | undefined): Promise<ErrorDtoAuthSuccessDTOEitherData[]> {
    let url_ = this.baseUrl + "/api/google-auth/sign-in";
    url_ = url_.replace(/[?&]$/, "");

    let options_: AxiosRequestConfig = {
      method: "POST",
      url: url_,
      headers: {
        "Authorization-Code": authorization_Code !== undefined && authorization_Code !== null ? "" + authorization_Code : "",
        "Accept": "text/plain"
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processSignIn2(_response);
    });
  }

  protected processSignIn2(response: AxiosResponse): Promise<ErrorDtoAuthSuccessDTOEitherData[]> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 200) {
      const _responseText = response.data;
      let result200: any = null;
      let resultData200  = _responseText;
      result200 = JSON.parse(resultData200);
      return Promise.resolve<ErrorDtoAuthSuccessDTOEitherData[]>(result200);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<ErrorDtoAuthSuccessDTOEitherData[]>(null as any);
  }

  /**
   * @param userId (optional)
   * @return Success
   */
  userMeal(userId: string | undefined , cancelToken?: CancelToken | undefined): Promise<void> {
    let url_ = this.baseUrl + "/api/meal/user-meal?";
    if (userId === null)
      throw new Error("The parameter 'userId' cannot be null.");
    else if (userId !== undefined)
      url_ += "userId=" + encodeURIComponent("" + userId) + "&";
    url_ = url_.replace(/[?&]$/, "");

    let options_: AxiosRequestConfig = {
      method: "GET",
      url: url_,
      headers: {
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processUserMeal(_response);
    });
  }

  protected processUserMeal(response: AxiosResponse): Promise<void> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 200) {
      const _responseText = response.data;
      return Promise.resolve<void>(null as any);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<void>(null as any);
  }

  /**
   * @param date (optional)
   * @param mealId (optional)
   * @return Success
   */
  allProducts(date: Date | undefined, mealId: string | undefined , cancelToken?: CancelToken | undefined): Promise<void> {
    let url_ = this.baseUrl + "/api/meal/all-products?";
    if (date === null)
      throw new Error("The parameter 'date' cannot be null.");
    else if (date !== undefined)
      url_ += "date=" + encodeURIComponent(date ? "" + date.toISOString() : "") + "&";
    if (mealId === null)
      throw new Error("The parameter 'mealId' cannot be null.");
    else if (mealId !== undefined)
      url_ += "mealId=" + encodeURIComponent("" + mealId) + "&";
    url_ = url_.replace(/[?&]$/, "");

    let options_: AxiosRequestConfig = {
      method: "GET",
      url: url_,
      headers: {
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processAllProducts(_response);
    });
  }

  protected processAllProducts(response: AxiosResponse): Promise<void> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 200) {
      const _responseText = response.data;
      return Promise.resolve<void>(null as any);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<void>(null as any);
  }

  /**
   * @param mealId (optional)
   * @return Success
   */
  nutrition(mealId: string | undefined , cancelToken?: CancelToken | undefined): Promise<void> {
    let url_ = this.baseUrl + "/api/meal/nutrition?";
    if (mealId === null)
      throw new Error("The parameter 'mealId' cannot be null.");
    else if (mealId !== undefined)
      url_ += "mealId=" + encodeURIComponent("" + mealId) + "&";
    url_ = url_.replace(/[?&]$/, "");

    let options_: AxiosRequestConfig = {
      method: "GET",
      url: url_,
      headers: {
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processNutrition(_response);
    });
  }

  protected processNutrition(response: AxiosResponse): Promise<void> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 200) {
      const _responseText = response.data;
      return Promise.resolve<void>(null as any);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<void>(null as any);
  }

  /**
   * @param dailyId (optional)
   * @return Success
   */
  meal(dailyId: string | undefined , cancelToken?: CancelToken | undefined): Promise<void> {
    let url_ = this.baseUrl + "/api/meal/meal?";
    if (dailyId === null)
      throw new Error("The parameter 'dailyId' cannot be null.");
    else if (dailyId !== undefined)
      url_ += "dailyId=" + encodeURIComponent("" + dailyId) + "&";
    url_ = url_.replace(/[?&]$/, "");

    let options_: AxiosRequestConfig = {
      method: "PUT",
      url: url_,
      headers: {
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processMeal(_response);
    });
  }

  protected processMeal(response: AxiosResponse): Promise<void> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 200) {
      const _responseText = response.data;
      return Promise.resolve<void>(null as any);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<void>(null as any);
  }

  /**
   * @param body (optional)
   * @return Success
   */
  nutritionGoalPOST(body: NutritionGoalDTO | undefined , cancelToken?: CancelToken | undefined): Promise<void> {
    let url_ = this.baseUrl + "/api/nutrition-goal";
    url_ = url_.replace(/[?&]$/, "");

    const content_ = JSON.stringify(body);

    let options_: AxiosRequestConfig = {
      data: content_,
      method: "POST",
      url: url_,
      headers: {
        "Content-Type": "application/json",
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processNutritionGoalPOST(_response);
    });
  }

  protected processNutritionGoalPOST(response: AxiosResponse): Promise<void> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 200) {
      const _responseText = response.data;
      return Promise.resolve<void>(null as any);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<void>(null as any);
  }

  /**
   * @return Success
   */
  nutritionGoalGET(  cancelToken?: CancelToken | undefined): Promise<void> {
    let url_ = this.baseUrl + "/api/nutrition-goal";
    url_ = url_.replace(/[?&]$/, "");

    let options_: AxiosRequestConfig = {
      method: "GET",
      url: url_,
      headers: {
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processNutritionGoalGET(_response);
    });
  }

  protected processNutritionGoalGET(response: AxiosResponse): Promise<void> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 200) {
      const _responseText = response.data;
      return Promise.resolve<void>(null as any);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<void>(null as any);
  }

  /**
   * @param name (optional)
   * @param volume (optional)
   * @param mealId (optional)
   * @return Success
   */
  productPOST(name: string | undefined, volume: number | undefined, mealId: string | undefined , cancelToken?: CancelToken | undefined): Promise<void> {
    let url_ = this.baseUrl + "/api/product?";
    if (name === null)
      throw new Error("The parameter 'name' cannot be null.");
    else if (name !== undefined)
      url_ += "name=" + encodeURIComponent("" + name) + "&";
    if (volume === null)
      throw new Error("The parameter 'volume' cannot be null.");
    else if (volume !== undefined)
      url_ += "volume=" + encodeURIComponent("" + volume) + "&";
    if (mealId === null)
      throw new Error("The parameter 'mealId' cannot be null.");
    else if (mealId !== undefined)
      url_ += "mealId=" + encodeURIComponent("" + mealId) + "&";
    url_ = url_.replace(/[?&]$/, "");

    let options_: AxiosRequestConfig = {
      method: "POST",
      url: url_,
      headers: {
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processProductPOST(_response);
    });
  }

  protected processProductPOST(response: AxiosResponse): Promise<void> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 200) {
      const _responseText = response.data;
      return Promise.resolve<void>(null as any);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<void>(null as any);
  }

  /**
   * @param productId (optional)
   * @param volume (optional)
   * @return Success
   */
  productPUT(productId: string | undefined, volume: number | undefined , cancelToken?: CancelToken | undefined): Promise<void> {
    let url_ = this.baseUrl + "/api/product?";
    if (productId === null)
      throw new Error("The parameter 'productId' cannot be null.");
    else if (productId !== undefined)
      url_ += "productId=" + encodeURIComponent("" + productId) + "&";
    if (volume === null)
      throw new Error("The parameter 'volume' cannot be null.");
    else if (volume !== undefined)
      url_ += "volume=" + encodeURIComponent("" + volume) + "&";
    url_ = url_.replace(/[?&]$/, "");

    let options_: AxiosRequestConfig = {
      method: "PUT",
      url: url_,
      headers: {
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processProductPUT(_response);
    });
  }

  protected processProductPUT(response: AxiosResponse): Promise<void> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 200) {
      const _responseText = response.data;
      return Promise.resolve<void>(null as any);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<void>(null as any);
  }

  /**
   * @param productId (optional)
   * @return Success
   */
  productDELETE(productId: string | undefined , cancelToken?: CancelToken | undefined): Promise<void> {
    let url_ = this.baseUrl + "/api/product?";
    if (productId === null)
      throw new Error("The parameter 'productId' cannot be null.");
    else if (productId !== undefined)
      url_ += "productId=" + encodeURIComponent("" + productId) + "&";
    url_ = url_.replace(/[?&]$/, "");

    let options_: AxiosRequestConfig = {
      method: "DELETE",
      url: url_,
      headers: {
      },
      cancelToken
    };

    return this.instance.request(options_).catch((_error: any) => {
      if (isAxiosError(_error) && _error.response) {
        return _error.response;
      } else {
        throw _error;
      }
    }).then((_response: AxiosResponse) => {
      return this.processProductDELETE(_response);
    });
  }

  protected processProductDELETE(response: AxiosResponse): Promise<void> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && typeof response.headers === "object") {
      for (let k in response.headers) {
        if (response.headers.hasOwnProperty(k)) {
          _headers[k] = response.headers[k];
        }
      }
    }
    if (status === 200) {
      const _responseText = response.data;
      return Promise.resolve<void>(null as any);

    } else if (status !== 200 && status !== 204) {
      const _responseText = response.data;
      return throwException("An unexpected server error occurred.", status, _responseText, _headers);
    }
    return Promise.resolve<void>(null as any);
  }
}

export interface ConfirmEmailDTO {
  userId?: string;
  url?: string | undefined;
}

export enum ErrorCode {
  _0 = 0,
  _1 = 1,
  _2 = 2,
  _3 = 3,
  _4 = 4,
  _5 = 5,
  _6 = 6,
}

export interface ErrorDto {
  message?: string | undefined;
  error?: ErrorCode;
}

export interface ErrorDtoAuthSuccessDTOEitherData {
}

export interface ErrorDtoSignUpResponseDtoEitherData {
}

export interface ForgotPasswordDTO {
  email?: string | undefined;
}

export interface NutritionGoalDTO {
  userId?: string;
  calories?: number;
  protein?: number;
  fat?: number;
  carbs?: number;
}

export interface RefreshTokenDTO {
  accessToken?: string | undefined;
  refreshToken?: string | undefined;
}

export interface ResendConfirmationUrlDTO {
  userId?: string;
}

export interface ResetPasswordDTO {
  email?: string | undefined;
  token?: string | undefined;
  newPassword?: string | undefined;
}

export interface SignInDTO {
  email?: string | undefined;
  password?: string | undefined;
}

export interface SignUpDTO {
  firstName?: string | undefined;
  lastName?: string | undefined;
  email?: string | undefined;
  password?: string | undefined;
}

export interface ValidationFailedErrorDTO {
  message?: string | undefined;
  error?: ErrorCode;
  body?: { [key: string]: string[]; } | undefined;
}

export class ApiException extends Error {
  override message: string;
  status: number;
  response: string;
  headers: { [key: string]: any; };
  result: any;

  constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
    super();

    this.message = message;
    this.status = status;
    this.response = response;
    this.headers = headers;
    this.result = result;
  }

  protected isApiException = true;

  static isApiException(obj: any): obj is ApiException {
    return obj.isApiException === true;
  }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
  if (result !== null && result !== undefined)
    throw result;
  else
    throw new ApiException(message, status, response, headers, null);
}

function isAxiosError(obj: any | undefined): obj is AxiosError {
  return obj && obj.isAxiosError === true;
}
