import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Answer } from '../models/Answer';
import { AnswersResponse } from '../models/response-models/AnswersResponse';
import { BaseResponse } from '../models/response-models/BaseResponse';
import { AnswerResponse } from '../models/response-models/AnswerResponse';
import { BooleanResponse } from '../models/response-models/BooleanResponse';

@Injectable({
  providedIn: 'root'
})

export class AnswersService extends BaseService {

  private headers: HttpHeaders;

  constructor(http: HttpClient) {
    super(http);
    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
  }

  async createAnswer(answer: Answer): Promise<BaseResponse<AnswerResponse>> {
    const response = await this.basePostRequest<BaseResponse<AnswerResponse>>('http://localhost:62989/api/Answers/CreateAnswer', JSON.stringify(answer), this.headers);
    return response;
  }
  
  async updateAnswer(answer: Answer): Promise<BaseResponse<AnswerResponse>> {
    const response = await this.basePutRequest<BaseResponse<AnswerResponse>>('http://localhost:62989/api/Answers/UpdateAnswer', JSON.stringify(answer), this.headers);
    return response;
  }

  async deleteAnswer(answerId: number): Promise<BaseResponse<BooleanResponse>> {
    var param: string = "?AnswerId=" + answerId;
    const response = await this.baseDeleteRequest<BaseResponse<BooleanResponse>>('http://localhost:62989/api/Answers/DeleteAnswer', param, this.headers);
    return response;
  }

  async getAnswersToQuestion(questionId: string): Promise<BaseResponse<AnswersResponse>> {
    var param: string = "?QuestionId=" + questionId;
    const response = await this.baseGetRequest<BaseResponse<AnswersResponse>>('http://localhost:62989/api/Answers/GetAnswers', param, this.headers);
    return response;
  }
}
