import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { QuestionTypesResponse } from '../models/response-models/QuestionTypesResponse';
import { QuestionTypeResponse } from '../models/response-models/QuestionTypeResponse';
import { BaseResponse } from '../models/response-models/BaseResponse';

@Injectable({
    providedIn: 'root'
})

export class QuestionTypeService extends BaseService {

    private headers: HttpHeaders;

    constructor(http: HttpClient) {
        super(http);
        this.headers = new HttpHeaders();
        this.headers = this.headers.set('Content-Type', 'application/json');
        this.headers = this.headers.set('Accept', 'application/json');
    }

    async getQuestionTypes(): Promise<BaseResponse<QuestionTypesResponse>> {
        const response = await this.baseGetRequest<BaseResponse<QuestionTypesResponse>>('http://localhost:62989/api/QuestionType/GetQuestionTypesList', "", this.headers);
        return response;
    }

    async getQuestionType(questionTypeId: number): Promise<BaseResponse<QuestionTypeResponse>> {
        const param = "?QuestionTypeId=" + questionTypeId;
        const response = await this.baseGetRequest<BaseResponse<QuestionTypeResponse>>('http://localhost:62989/api/QuestionType/GetQuestionType', param, this.headers);
        return response;
    }
}