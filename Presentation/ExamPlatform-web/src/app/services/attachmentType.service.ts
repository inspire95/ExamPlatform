
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AttachmentTypesResponse } from '../models/response-models/AttachmentTypesResponse';
import { BaseService } from './base.service';
import { BaseResponse } from '../models/response-models/BaseResponse';

@Injectable({
  providedIn: 'root'
})

export class AttachmentTypeService extends BaseService {

  private headers: HttpHeaders;

  constructor(http: HttpClient) {
    super(http);
    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
  }

  async getAttachmentTypes(): Promise<BaseResponse<AttachmentTypesResponse>> {
    const response = await this.baseGetRequest<BaseResponse<AttachmentTypesResponse>>('http://localhost:62989/api/AttachmentType/GetAttachmentTypes', "", this.headers);
    return response;
  }
}
