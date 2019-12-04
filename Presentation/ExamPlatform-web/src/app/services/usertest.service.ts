import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { UserTest } from '../models/UserTest';
import { UserTestsResponse } from '../models/response-models/UserTestsResponse';
import { UserTestResponse } from '../models/response-models/UserTestResponse';
import { BaseResponse } from '../models/response-models/BaseResponse';
import { BooleanResponse } from '../models/response-models/BooleanResponse';

@Injectable({
  providedIn: 'root'
})

export class UserTestService extends BaseService {

  private headers: HttpHeaders;

  constructor(http: HttpClient) {
    super(http);
    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
  }

  async getAllUserTests(UserId: string): Promise<BaseResponse<UserTestsResponse>> {
    const param = "?UserId=" + UserId;
    const response = await this.baseGetRequest<BaseResponse<UserTestsResponse>>('http://localhost:62989/api/UserTests/GetUserTests', param, this.headers);
    return response;
  }

  async getUserTest(UserTestId: string): Promise<BaseResponse<UserTestResponse>> {
    const param = "?UserTestId=" + UserTestId;
    const response = await this.baseGetRequest<BaseResponse<UserTestResponse>>('http://localhost:62989/api/UserTests/GetUserTest', param, this.headers);
        return response;
  }

  async createUserTest(userTest: UserTest): Promise<BaseResponse<UserTestResponse>> {
    const response = await this.basePostRequest<BaseResponse<UserTestResponse>>('http://localhost:62989/api/UserTests/CreateUserTest', JSON.stringify(userTest), this.headers);
    return response;
  }

  async startUserTest(userTestId: string): Promise<BaseResponse<BooleanResponse>> {
    var startUserTestRequest: StartUserTestRequest = {
      userTestId: userTestId,
      startDate: this.formatDate(new Date())
    };
    const response = await this.basePostRequest<BaseResponse<BooleanResponse>>('http://localhost:62989/api/UserTests/StartUserTest', JSON.stringify(startUserTestRequest), this.headers);
    return response;
  }

  async finishUserTest(_userTestId: string): Promise<BaseResponse<BooleanResponse>>{
    var finishUserTestRequest: FinishUserTestRequest = {
      userTestId: _userTestId,
      endDate: this.formatDate(new Date())
    };
    const response = await this.basePostRequest<BaseResponse<BooleanResponse>>('http://localhost:62989/api/UserTests/FinishUserTest', JSON.stringify(finishUserTestRequest), this.headers);
    return response;
  }

  async CheckSummaryUserTest(userTestId: string): Promise<BaseResponse<BooleanResponse>>{
    console.log(userTestId)
    var param = "?UserTestId=" + userTestId;
    const response = await this.baseGetRequest<BaseResponse<BooleanResponse>>('http://localhost:62989/api/UserTests/CheckSummary', param, this.headers);
    return response;
  }

  private formatDate(d: Date): string {
    var date_format_str = d.getFullYear().toString() + "-" +
      ((d.getMonth() + 1).toString().length == 2 ? (d.getMonth() + 1).toString() : "0" + (d.getMonth() + 1).toString()) + "-" +
      (d.getDate().toString().length == 2 ? d.getDate().toString() : "0" + d.getDate().toString()) + "T" +
      (d.getHours().toString().length == 2 ? d.getHours().toString() : "0" + d.getHours().toString()) + ":" +
      ((d.getMinutes() / 5 * 5).toString().length == 2 ? (d.getMinutes() / 5 * 5).toString() : "0" + (d.getMinutes() / 5 * 5).toString()) + ":" +
      (d.getSeconds().toString().length == 2 ? d.getSeconds().toString() : "0" + d.getSeconds().toString()) + "Z";

    return date_format_str;
  }
}

export interface StartUserTestRequest {
  userTestId: string;
  startDate: string;
}

export interface FinishUserTestRequest {
  userTestId: string;
  endDate: string;
}
