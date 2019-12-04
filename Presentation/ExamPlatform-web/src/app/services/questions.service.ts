import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { QuestionsResponse } from '../models/response-models/QuestionsResponse';
import { QuestionResponse } from '../models/response-models/QuestionResponse';
import { Question } from '../models/Question';
import { BaseResponse } from '../models/response-models/BaseResponse';
import { BooleanResponse } from '../models/response-models/BooleanResponse';

@Injectable({
  providedIn: 'root'
})

export class QuestionsService extends BaseService {

  private headers: HttpHeaders;

  constructor(http: HttpClient) {
    super(http);
    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
  }

  async getAllQuestions(): Promise<BaseResponse<QuestionsResponse>> {
    const response = await this.baseGetRequest<BaseResponse<QuestionsResponse>>('http://localhost:62989/api/Questions/GetQuestions', "", this.headers);
    return response;
  }

  async getQuestion(QuestionId: string): Promise<BaseResponse<QuestionResponse>> {
    const param = "?QuestionId=" + QuestionId;
    const response = await this.baseGetRequest<BaseResponse<QuestionResponse>>('http://localhost:62989/api/Questions/GetQuestionDetails', param, this.headers);
    return response;
  }

  async createQuestion(question: Question): Promise<BaseResponse<QuestionResponse>> {
    const response = await this.basePostRequest<BaseResponse<QuestionResponse>>('http://localhost:62989/api/Questions/CreateQuestion', JSON.stringify(question), this.headers);
    return response;
  }

  async updateQuestion(question: Question): Promise<BaseResponse<QuestionResponse>> {
    const response = await this.basePutRequest<BaseResponse<QuestionResponse>>('http://localhost:62989/api/Questions/UpdateQuestion', JSON.stringify(question), this.headers);
    return response;
  }

  async deleteQuestion(QuestionId: string): Promise<BaseResponse<BooleanResponse>>{
    const param = "?QuestionId=" + QuestionId;
    const response = await this.baseDeleteRequest<BaseResponse<BooleanResponse>>('http://localhost:62989/api/Questions/DeleteQuestion', param, this.headers);
    return response;
  }
}