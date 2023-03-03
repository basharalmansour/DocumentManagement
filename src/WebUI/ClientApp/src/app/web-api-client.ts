/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.14.4.0 (NJsonSchema v10.5.2.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

export interface ICustomerClient {
    sendOtp(sendOtpToCustomerCommand: SendOtpToCustomerCommand): Observable<SendOtpMessageResult>;
}

@Injectable({
    providedIn: 'root'
})
export class CustomerClient implements ICustomerClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    sendOtp(sendOtpToCustomerCommand: SendOtpToCustomerCommand) : Observable<SendOtpMessageResult> {
        let url_ = this.baseUrl + "/api/Customer/SendOtpMessage";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(sendOtpToCustomerCommand);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/json"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processSendOtp(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processSendOtp(<any>response_);
                } catch (e) {
                    return <Observable<SendOtpMessageResult>><any>_observableThrow(e);
                }
            } else
                return <Observable<SendOtpMessageResult>><any>_observableThrow(response_);
        }));
    }

    protected processSendOtp(response: HttpResponseBase): Observable<SendOtpMessageResult> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = SendOtpMessageResult.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status === 400) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result400: any = null;
            let resultData400 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result400 = ErrorResponseModel.fromJS(resultData400);
            return throwException("A server side error occurred.", status, _responseText, _headers, result400);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<SendOtpMessageResult>(<any>null);
    }
}

export class SendOtpMessageResult implements ISendOtpMessageResult {
    result?: boolean;

    constructor(data?: ISendOtpMessageResult) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.result = _data["result"];
        }
    }

    static fromJS(data: any): SendOtpMessageResult {
        data = typeof data === 'object' ? data : {};
        let result = new SendOtpMessageResult();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["result"] = this.result;
        return data; 
    }
}

export interface ISendOtpMessageResult {
    result?: boolean;
}

export class ErrorResponseModel implements IErrorResponseModel {
    message?: string | undefined;

    constructor(data?: IErrorResponseModel) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.message = _data["message"];
        }
    }

    static fromJS(data: any): ErrorResponseModel {
        data = typeof data === 'object' ? data : {};
        let result = new ErrorResponseModel();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["message"] = this.message;
        return data; 
    }
}

export interface IErrorResponseModel {
    message?: string | undefined;
}

export class SendOtpToCustomerCommand implements ISendOtpToCustomerCommand {
    token?: string | undefined;
    customerId?: number;
    phoneNumber?: string | undefined;

    constructor(data?: ISendOtpToCustomerCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.token = _data["token"];
            this.customerId = _data["customerId"];
            this.phoneNumber = _data["phoneNumber"];
        }
    }

    static fromJS(data: any): SendOtpToCustomerCommand {
        data = typeof data === 'object' ? data : {};
        let result = new SendOtpToCustomerCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["token"] = this.token;
        data["customerId"] = this.customerId;
        data["phoneNumber"] = this.phoneNumber;
        return data; 
    }
}

export interface ISendOtpToCustomerCommand {
    token?: string | undefined;
    customerId?: number;
    phoneNumber?: string | undefined;
}

export class SwaggerException extends Error {
    message: string;
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

    protected isSwaggerException = true;

    static isSwaggerException(obj: any): obj is SwaggerException {
        return obj.isSwaggerException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new SwaggerException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next((<any>event.target).result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}