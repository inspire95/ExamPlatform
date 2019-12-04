import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { UserTestAnswersResponse } from '../models/response-models/UserTestAnswersResponse';
import { UserTestAnswer } from '../models/UserTestAnswer';
import { BaseResponse } from '../models/response-models/BaseResponse';
import { UserTestAnswerResponse } from '../models/response-models/UserTestAnswerResponse';
import { BooleanResponse } from '../models/response-models/BooleanResponse';

@Injectable({
  providedIn: 'root'
})

export class UserTestAnswerService extends BaseService {

  private headers: HttpHeaders;

  constructor(http: HttpClient) {
    super(http);
    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
  }

  async getUserAnswers(userTestId: string): Promise<BaseResponse<UserTestAnswersResponse>> {
    var param = "?UserTestId=" + userTestId;
    const response = await this.baseGetRequest<BaseResponse<UserTestAnswersResponse>>('http://localhost:62989/api/UserTestAnswers/GetUserTestAnswersList', param, this.headers);
    return response;
  }

  async getUserTestOpenAnswers(userTestId: string): Promise<UserTestAnswersResponse> {
    var param = "?UserTestId=" + userTestId;
    const response = await this.baseGetRequest<UserTestAnswersResponse>('http://localhost:62989/api/UserTestAnswers/GetUserTestOpenAnswersList', param, this.headers);
    return response;
  }

  async getUserAnswersToQuestion(userTestId: string, questionId: number): Promise<BaseResponse<UserTestAnswersResponse>> {
    var param = "?UserTestId=" + userTestId + "&QuestionId=" + questionId;
    const response = await this.baseGetRequest<BaseResponse<UserTestAnswersResponse>>('http://localhost:62989/api/UserTestAnswers/GetUserAnswersToQuestion', param, this.headers);
    return response;
  }

  async createUserAnswer(userTestAnswer: UserTestAnswer): Promise<BaseResponse<UserTestAnswerResponse>> {
    const response = await this.basePostRequest<BaseResponse<UserTestAnswerResponse>>('http://localhost:62989/api/UserTestAnswers/CreateUserTestAnswer', JSON.stringify(userTestAnswer), this.headers);
    return response;
  }

  async deleteUserAnswersByQuestion(userTestId: string, questionId: number): Promise<BaseResponse<BooleanResponse>> {
    var param = "?UserTestId=" + userTestId + "&QuestionId=" + questionId;
    const response = await this.baseDeleteRequest<BaseResponse<BooleanResponse>>('http://localhost:62989/api/UserTestAnswers/DeleteUserAnswersByQustion', param, this.headers);
    return response;
  }

  async verifyOpenUserAnswer(userTestAnswerId: number, aquiredPoints: number): Promise<BaseResponse<UserTestAnswerResponse>> {
    console.log(userTestAnswerId)
    var param = "?UserTestAnswerId=" + userTestAnswerId + "&PointsForOpenQuestion=" + aquiredPoints;
    const response = await this.baseGetRequest<BaseResponse<UserTestAnswerResponse>>('http://localhost:62989/api/UserTestAnswers/VerifyOpenUserAnswer', param, this.headers);
    console.log(response)
    return response;
  }
}
