import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from "@angular/forms"
import { HttpClient } from "@angular/common/http"
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from './../services/auth.service';
import { mdlLoginRequest, mdlLoginResponse } from '../interface/auth';
import { enmMessageType } from '../interface/enums';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  private returnUrl: string;
  public loginForm !: FormGroup;
  public baseUrl: string;
  errorMessage: string = '';
  errorFailcountMessage: string = '';
  showError: boolean;
  public isImageLoading: boolean;
  public imageData: any;
  private imageId: string;
  private orgCode: string;
   

  constructor(private formBuilder: FormBuilder, private http: HttpClient,
    @Inject('API_BASE_URL') baseUrl: string, @Inject('OrgCode') OrgCode: string, private router: Router, private route: ActivatedRoute,
    private authService: AuthService, private sanitizer: DomSanitizer
  ) {
    this.baseUrl = baseUrl;
    this.showError = false;
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.isImageLoading = true;
    this.imageId = "";
    this.orgCode = OrgCode;
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      userName: ['', [Validators.required, Validators.maxLength(25), Validators.minLength(3)]],
      password: ['', [Validators.required, Validators.maxLength(25), Validators.minLength(3)]],
      captcha: ['', [Validators.required, Validators.pattern("[A-Z0-9]{4}")]]
    })
    this.getCaptcha();
  }

  getCaptcha() {
    this.isImageLoading = true;
    this.authService.getCaptcha(0, 100, 40).subscribe(res => {
      if (res.messageType == enmMessageType.Success) {
        this.imageData = this.sanitizer.bypassSecurityTrustUrl('data:image/png;base64,' + res.returnId);
        this.imageId = res.message;        
        this.isImageLoading = false;    
      }
      else {
        this.errorMessage = res.error.message;
        this.showError = true;
      }
    }, err => {
      this.errorMessage = err.message;
      this.showError = true;
    });
  }

  validateControl(controlName: string) {
    return this.loginForm.get(controlName)?.invalid && this.loginForm.get(controlName)?.touched
  }
  hasError (controlName: string, errorName: string) {
    return this.loginForm.get(controlName)?.hasError(errorName)
  }

  login() {
    const _log = { ...this.loginForm.value };
    const req: mdlLoginRequest = {
      userName: _log.userName,
      password: _log.password,
      orgCode: this.orgCode,
      captchaId: this.imageId,
      captchaValue: _log.captcha,
      height: 40,
      width: 100,
      longitude: "",
      latitude:""

    };
    this.authService.doLogin(req).subscribe(res => {
      if (res.messageType == enmMessageType.Success) {
        localStorage.setItem("token", res.token);
        localStorage.setItem("userId", res.userIdHex);
        localStorage.setItem("orgId", res.orgId.toString());
        localStorage.setItem("normalizedName", res.normalizedName);
        localStorage.setItem("userType", res.userType.toString());
        this.router.navigate([this.returnUrl]);
      }
      else {
        this.errorMessage = res.error.message;
        this.errorFailcountMessage = "Login fail count " + res.failCount
        this.imageData = this.sanitizer.bypassSecurityTrustUrl('data:image/png;base64,' + res.captchaImages);
        this.imageId = res.captchaId;        
        this.showError = true;
      }
    }, err => {
      this.errorMessage = err.message;
      this.showError = true;
    });
  }
}
