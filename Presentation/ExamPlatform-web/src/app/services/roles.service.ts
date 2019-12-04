import { Injectable } from '@angular/core'
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { RolesResponse } from '../models/response-models/RolesResponse';
import { RoleResponse } from '../models/response-models/RoleResponse';
import { BaseResponse } from '../models/response-models/BaseResponse';

@Injectable({
    providedIn: 'root'
})

export class RolesService extends BaseService{

    private headers: HttpHeaders;

    constructor(http: HttpClient) {
      super(http);
      this.headers = new HttpHeaders();
      this.headers = this.headers.set('Content-Type', 'application/json');
      this.headers = this.headers.set('Accept', 'application/json');
    }
  
    async getAllRoles(): Promise<BaseResponse<RolesResponse>> {
      const response = await this.baseGetRequest<BaseResponse<RolesResponse>>('http://localhost:62989/api/Roles/GetRoles', "", this.headers);
      return response;
    }
  
    async getRole(RoleId: string): Promise<BaseResponse<RoleResponse>> {
      const param = "?RoleId=" + RoleId;
      const response = await this.baseGetRequest<BaseResponse<RoleResponse>>('http://localhost:62989/api/Roles/GetRole', param, this.headers);
      return response;
    }
}