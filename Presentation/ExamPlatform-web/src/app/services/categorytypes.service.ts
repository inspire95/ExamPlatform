import { Injectable } from '@angular/core';
import { CategoryType } from '../models/CategoryType';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { BaseResponse } from '../models/response-models/BaseResponse';
import { CategoryTypeResponse } from '../models/response-models/CategoryTypeResponse';
import { CategoryTypesResponse } from '../models/response-models/CategoryTypesResponse';
import { BooleanResponse } from '../models/response-models/BooleanResponse';

@Injectable({
  providedIn: 'root'
})

export class CategoryTypeService extends BaseService {

  private headers: HttpHeaders;

  constructor(http: HttpClient) {
    super(http);
    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
  }

  async getAllCategoryTypes(): Promise<BaseResponse<CategoryTypesResponse>> {
    const response = await this.baseGetRequest<BaseResponse<CategoryTypesResponse>>('http://localhost:62989/api/CategoryTypes/GetCategoryTypes', "", this.headers);
    return response;
  }

  async getCategory(CategoryTypeId: string): Promise<BaseResponse<CategoryTypeResponse>> {
    const param = "?CategoryTypeId=" + CategoryTypeId;
    const response = await this.baseGetRequest<BaseResponse<CategoryTypeResponse>>('http://localhost:62989/api/CategoryTypes/GetCategoryTypeDetails', param, this.headers);
    return response;
  }

  async createCategory(categoryType: CategoryType): Promise<BaseResponse<CategoryTypeResponse>> {
    const response = await this.basePostRequest<BaseResponse<CategoryTypeResponse>>('http://localhost:62989/api/CategoryTypes/CreateCategoryType', JSON.stringify(categoryType), this.headers);
    return response;
  }

  async updateCategory(categoryType: CategoryType): Promise<BaseResponse<CategoryTypeResponse>> {
    const response = await this.basePutRequest<BaseResponse<CategoryTypeResponse>>('http://localhost:62989/api/CategoryTypes/UpdateCategoryType', JSON.stringify(categoryType), this.headers);
    return response;
  }

  async deleteCategory(CategoryTypeId: string): Promise<BooleanResponse> {
    const param = "?CategoryTypeId=" + CategoryTypeId;
    const response = await this.baseDeleteRequest<BooleanResponse>('http://localhost:62989/api/CategoryTypes/DeleteCategoryType', param, this.headers);
    return response;
  }
}