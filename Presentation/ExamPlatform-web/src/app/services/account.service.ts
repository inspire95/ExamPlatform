import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Account } from '../models/Account';
import { HttpHeaders } from '@angular/common/http';

@Injectable()
export class AccountService {

  selectedUser: Account;

  constructor(private http: HttpClient) { }

  userAuthentication(user: Account){
    var body = JSON.stringify(user);
    return this.http.post('http://localhost:62989/api/Account/authenticate',body, {headers: new HttpHeaders({'Content-Type':'application/json', 'No-Auth': 'True'})});
  }
}