import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TestResponse } from '../models/response-models/TestResponse';
import { TestsResponse } from '../models/response-models/TestsResponse';
import { Test } from '../models/Test';
import { BaseService } from './base.service';
import { BaseResponse } from '../models/response-models/BaseResponse';
import { BooleanResponse } from '../models/response-models/BooleanResponse';
import { GeneratedTest } from '../models/GeneratedTest';

@Injectable({
  providedIn: 'root'
})

export class TestsService extends BaseService {

  private headers: HttpHeaders;

  constructor(http: HttpClient) {
    super(http);
    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
  }

  async getAllTests(): Promise<BaseResponse<TestsResponse>> {
    const response = await this.baseGetRequest<BaseResponse<TestsResponse>>('http://localhost:62989/api/Tests/GetTests', "", this.headers);
    return response;
  }

  async getTest(TestId: string): Promise<BaseResponse<TestResponse>> {
    const param = "?TestId=" + TestId;
    const response = await this.baseGetRequest<BaseResponse<TestResponse>>('http://localhost:62989/api/Tests/GetTestDetails', param, this.headers);
    return response;
  }

  async createTest(test: Test): Promise<BaseResponse<TestResponse>> {
    const response = await this.basePostRequest<BaseResponse<TestResponse>>('http://localhost:62989/api/Tests/CreateTest', JSON.stringify(test), this.headers);
    return response;
  }

  async updateTest(test: Test): Promise<BaseResponse<TestResponse>> {
    const response = await this.basePutRequest<BaseResponse<TestResponse>>('http://localhost:62989/api/Tests/UpdateTest', JSON.stringify(test), this.headers);
    return response;
  }

  async generateTest(test: GeneratedTest): Promise<BaseResponse<TestResponse>> {
    console.log(test);
    
    const response = await this.basePostRequest<BaseResponse<TestResponse>>('http://localhost:62989/api/Tests/GenerateTest', JSON.stringify(test), this.headers);
    return response;
  }

  async deleteTest(TestId: string): Promise<BaseResponse<BooleanResponse>>{
    const param = "?TestId=" + TestId;
    const response = await this.baseDeleteRequest<BaseResponse<BooleanResponse>>('http://localhost:62989/api/Tests/DeleteTest', param, this.headers);
    return response;
  }
}
