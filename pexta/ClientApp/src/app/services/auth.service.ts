import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from "@angular/common/http"
import { mdlLoginRequest, mdlLoginResponse } from './../interface/auth';
import { Observable } from 'rxjs';
import { mdlReturnData } from '../interface/common';
//import { OidcSecurityService } from 'angular-auth-oidc-client';

@Injectable()
export class AuthService {
  private baseUrl: string;
  
  
  constructor(private http: HttpClient, @Inject('API_BASE_URL') apiBaseUrl: string) {
    this.baseUrl = apiBaseUrl;    
  }

  //get isLoggedIn() {
  //  return this.oidcSecurityService.isAuthenticated$;
  //}

  //get token() {
  //  return this.oidcSecurityService.getToken();
  //}

  //get userData() {
  //  return this.oidcSecurityService.userData$;
  //}

  //checkAuth() {
  //  return this.oidcSecurityService.checkAuth();
  //}

  doLogin(body: mdlLoginRequest): Observable<mdlLoginResponse>{
    return this.http.post<mdlLoginResponse>(this.baseUrl + 'api/user/login', body)
  }

  getCaptcha(UserId: number, width: number, height: number): Observable<mdlReturnData> {
    return this.http.get<mdlReturnData>(this.baseUrl + 'api/user/GetCaptcha/' + UserId + "/" + width + "/" + height);
  }


  
  

  //signOut() {
  //  this.oidcSecurityService.logoff();
  //}
}
