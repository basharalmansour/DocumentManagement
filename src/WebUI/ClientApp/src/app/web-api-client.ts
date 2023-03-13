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

export interface IFormClient {
    createForm(request: CreateFormCommnad): Observable<FileResponse>;
    getForms(request: GetFormsQuery): Observable<FileResponse>;
    getFormById(request: GetFormByIdQuery): Observable<FileResponse>;
    editForm(request: EditFormCommand): Observable<FileResponse>;
    deleteForm(request: RemoveFormCommand): Observable<FileResponse>;
}

@Injectable({
    providedIn: 'root'
})
export class FormClient implements IFormClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    createForm(request: CreateFormCommnad) : Observable<FileResponse> {
        let url_ = this.baseUrl + "/api/Form/AddForm";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(request);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/octet-stream"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processCreateForm(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processCreateForm(<any>response_);
                } catch (e) {
                    return <Observable<FileResponse>><any>_observableThrow(e);
                }
            } else
                return <Observable<FileResponse>><any>_observableThrow(response_);
        }));
    }

    protected processCreateForm(response: HttpResponseBase): Observable<FileResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return _observableOf({ fileName: fileName, data: <any>responseBlob, status: status, headers: _headers });
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<FileResponse>(<any>null);
    }

    getForms(request: GetFormsQuery) : Observable<FileResponse> {
        let url_ = this.baseUrl + "/api/Form/ViewForms";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(request);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/octet-stream"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetForms(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetForms(<any>response_);
                } catch (e) {
                    return <Observable<FileResponse>><any>_observableThrow(e);
                }
            } else
                return <Observable<FileResponse>><any>_observableThrow(response_);
        }));
    }

    protected processGetForms(response: HttpResponseBase): Observable<FileResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return _observableOf({ fileName: fileName, data: <any>responseBlob, status: status, headers: _headers });
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<FileResponse>(<any>null);
    }

    getFormById(request: GetFormByIdQuery) : Observable<FileResponse> {
        let url_ = this.baseUrl + "/api/Form/ViewFormById";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(request);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/octet-stream"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetFormById(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetFormById(<any>response_);
                } catch (e) {
                    return <Observable<FileResponse>><any>_observableThrow(e);
                }
            } else
                return <Observable<FileResponse>><any>_observableThrow(response_);
        }));
    }

    protected processGetFormById(response: HttpResponseBase): Observable<FileResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return _observableOf({ fileName: fileName, data: <any>responseBlob, status: status, headers: _headers });
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<FileResponse>(<any>null);
    }

    editForm(request: EditFormCommand) : Observable<FileResponse> {
        let url_ = this.baseUrl + "/api/Form/EditForm";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(request);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/octet-stream"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processEditForm(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processEditForm(<any>response_);
                } catch (e) {
                    return <Observable<FileResponse>><any>_observableThrow(e);
                }
            } else
                return <Observable<FileResponse>><any>_observableThrow(response_);
        }));
    }

    protected processEditForm(response: HttpResponseBase): Observable<FileResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return _observableOf({ fileName: fileName, data: <any>responseBlob, status: status, headers: _headers });
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<FileResponse>(<any>null);
    }

    deleteForm(request: RemoveFormCommand) : Observable<FileResponse> {
        let url_ = this.baseUrl + "/api/Form/DeleteForm";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(request);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/octet-stream"
            })
        };

        return this.http.request("delete", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processDeleteForm(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processDeleteForm(<any>response_);
                } catch (e) {
                    return <Observable<FileResponse>><any>_observableThrow(e);
                }
            } else
                return <Observable<FileResponse>><any>_observableThrow(response_);
        }));
    }

    protected processDeleteForm(response: HttpResponseBase): Observable<FileResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return _observableOf({ fileName: fileName, data: <any>responseBlob, status: status, headers: _headers });
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<FileResponse>(<any>null);
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

export class CreateFormCommnad implements ICreateFormCommnad {
    name?: string | undefined;
    questions?: AddQuestionRequest[] | undefined;

    constructor(data?: ICreateFormCommnad) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.name = _data["name"];
            if (Array.isArray(_data["questions"])) {
                this.questions = [] as any;
                for (let item of _data["questions"])
                    this.questions!.push(AddQuestionRequest.fromJS(item));
            }
        }
    }

    static fromJS(data: any): CreateFormCommnad {
        data = typeof data === 'object' ? data : {};
        let result = new CreateFormCommnad();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        if (Array.isArray(this.questions)) {
            data["questions"] = [];
            for (let item of this.questions)
                data["questions"].push(item.toJSON());
        }
        return data; 
    }
}

export interface ICreateFormCommnad {
    name?: string | undefined;
    questions?: AddQuestionRequest[] | undefined;
}

export class AddQuestionRequest implements IAddQuestionRequest {
    name?: string | undefined;
    questionType?: QuestionType;
    answersCount?: number;
    formId?: number;
    dateQuestionOptions?: DateQuestionOptionsDto[] | undefined;
    fileQuestionOptions?: FileQuestionOptionsDto[] | undefined;
    multiChoicesQuestions?: MultiChoicesQuestionDto[] | undefined;

    constructor(data?: IAddQuestionRequest) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.name = _data["name"];
            this.questionType = _data["questionType"];
            this.answersCount = _data["answersCount"];
            this.formId = _data["formId"];
            if (Array.isArray(_data["dateQuestionOptions"])) {
                this.dateQuestionOptions = [] as any;
                for (let item of _data["dateQuestionOptions"])
                    this.dateQuestionOptions!.push(DateQuestionOptionsDto.fromJS(item));
            }
            if (Array.isArray(_data["fileQuestionOptions"])) {
                this.fileQuestionOptions = [] as any;
                for (let item of _data["fileQuestionOptions"])
                    this.fileQuestionOptions!.push(FileQuestionOptionsDto.fromJS(item));
            }
            if (Array.isArray(_data["multiChoicesQuestions"])) {
                this.multiChoicesQuestions = [] as any;
                for (let item of _data["multiChoicesQuestions"])
                    this.multiChoicesQuestions!.push(MultiChoicesQuestionDto.fromJS(item));
            }
        }
    }

    static fromJS(data: any): AddQuestionRequest {
        data = typeof data === 'object' ? data : {};
        let result = new AddQuestionRequest();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        data["questionType"] = this.questionType;
        data["answersCount"] = this.answersCount;
        data["formId"] = this.formId;
        if (Array.isArray(this.dateQuestionOptions)) {
            data["dateQuestionOptions"] = [];
            for (let item of this.dateQuestionOptions)
                data["dateQuestionOptions"].push(item.toJSON());
        }
        if (Array.isArray(this.fileQuestionOptions)) {
            data["fileQuestionOptions"] = [];
            for (let item of this.fileQuestionOptions)
                data["fileQuestionOptions"].push(item.toJSON());
        }
        if (Array.isArray(this.multiChoicesQuestions)) {
            data["multiChoicesQuestions"] = [];
            for (let item of this.multiChoicesQuestions)
                data["multiChoicesQuestions"].push(item.toJSON());
        }
        return data; 
    }
}

export interface IAddQuestionRequest {
    name?: string | undefined;
    questionType?: QuestionType;
    answersCount?: number;
    formId?: number;
    dateQuestionOptions?: DateQuestionOptionsDto[] | undefined;
    fileQuestionOptions?: FileQuestionOptionsDto[] | undefined;
    multiChoicesQuestions?: MultiChoicesQuestionDto[] | undefined;
}

export enum QuestionType {
    MultiAnswer = 0,
    OneOfMany = 1,
    DateAnswer = 2,
    FileAnswer = 3,
    TextAnswer = 4,
}

export class DateQuestionOptionsDto implements IDateQuestionOptionsDto {
    isMultiDate?: boolean;
    questionId?: number;

    constructor(data?: IDateQuestionOptionsDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.isMultiDate = _data["isMultiDate"];
            this.questionId = _data["questionId"];
        }
    }

    static fromJS(data: any): DateQuestionOptionsDto {
        data = typeof data === 'object' ? data : {};
        let result = new DateQuestionOptionsDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["isMultiDate"] = this.isMultiDate;
        data["questionId"] = this.questionId;
        return data; 
    }
}

export interface IDateQuestionOptionsDto {
    isMultiDate?: boolean;
    questionId?: number;
}

export class FileQuestionOptionsDto implements IFileQuestionOptionsDto {
    documentFileType?: DocumentFileType;
    questionId?: number;

    constructor(data?: IFileQuestionOptionsDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.documentFileType = _data["documentFileType"];
            this.questionId = _data["questionId"];
        }
    }

    static fromJS(data: any): FileQuestionOptionsDto {
        data = typeof data === 'object' ? data : {};
        let result = new FileQuestionOptionsDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["documentFileType"] = this.documentFileType;
        data["questionId"] = this.questionId;
        return data; 
    }
}

export interface IFileQuestionOptionsDto {
    documentFileType?: DocumentFileType;
    questionId?: number;
}

export enum DocumentFileType {
    PDF = 0,
    Word = 1,
    TxtFile = 2,
}

export class MultiChoicesQuestionDto implements IMultiChoicesQuestionDto {
    choice?: string | undefined;
    questionId?: number;

    constructor(data?: IMultiChoicesQuestionDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.choice = _data["choice"];
            this.questionId = _data["questionId"];
        }
    }

    static fromJS(data: any): MultiChoicesQuestionDto {
        data = typeof data === 'object' ? data : {};
        let result = new MultiChoicesQuestionDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["choice"] = this.choice;
        data["questionId"] = this.questionId;
        return data; 
    }
}

export interface IMultiChoicesQuestionDto {
    choice?: string | undefined;
    questionId?: number;
}

export class GetFormsQuery implements IGetFormsQuery {

    constructor(data?: IGetFormsQuery) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
    }

    static fromJS(data: any): GetFormsQuery {
        data = typeof data === 'object' ? data : {};
        let result = new GetFormsQuery();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        return data; 
    }
}

export interface IGetFormsQuery {
}

export class GetFormByIdQuery implements IGetFormByIdQuery {
    id?: number;

    constructor(data?: IGetFormByIdQuery) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
        }
    }

    static fromJS(data: any): GetFormByIdQuery {
        data = typeof data === 'object' ? data : {};
        let result = new GetFormByIdQuery();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        return data; 
    }
}

export interface IGetFormByIdQuery {
    id?: number;
}

export class EditFormCommand extends CreateFormCommnad implements IEditFormCommand {
    id?: number;

    constructor(data?: IEditFormCommand) {
        super(data);
    }

    init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.id = _data["id"];
        }
    }

    static fromJS(data: any): EditFormCommand {
        data = typeof data === 'object' ? data : {};
        let result = new EditFormCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        super.toJSON(data);
        return data; 
    }
}

export interface IEditFormCommand extends ICreateFormCommnad {
    id?: number;
}

export class RemoveFormCommand implements IRemoveFormCommand {
    id?: number;

    constructor(data?: IRemoveFormCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
        }
    }

    static fromJS(data: any): RemoveFormCommand {
        data = typeof data === 'object' ? data : {};
        let result = new RemoveFormCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        return data; 
    }
}

export interface IRemoveFormCommand {
    id?: number;
}

export interface FileResponse {
    data: Blob;
    status: number;
    fileName?: string;
    headers?: { [name: string]: any };
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