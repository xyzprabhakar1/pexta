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
  showError: boolean;
  public isImageLoading: boolean;
  public imageData: any;
  public imageId: string;
   

  constructor(private formBuilder: FormBuilder, private http: HttpClient,
    @Inject('API_BASE_URL') baseUrl: string, private router: Router, private route: ActivatedRoute,
    private authService: AuthService, private sanitizer: DomSanitizer
  ) {
    this.baseUrl = baseUrl;
    this.showError = false;
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.isImageLoading = true;
    this.imageId = "";
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      userName: ['', [Validators.required, Validators.maxLength(25)]],
      password: ['', [Validators.required, Validators.maxLength(25)]],
      captcha: ['', [Validators.required]]
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
      password: _log.password
    };
    this.authService.doLogin(req).subscribe(res => {
      if (res.isSuccess) {
        localStorage.setItem("token", res.token);
        this.router.navigate([this.returnUrl]);
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

}
