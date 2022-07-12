import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from "@angular/forms"
import { HttpClient } from "@angular/common/http"
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from './../services/auth.service';
import { mdlLoginRequest, mdlLoginResponse } from '../interface/auth';

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

  constructor(private formBuilder: FormBuilder, private http: HttpClient,
    @Inject('API_BASE_URL') baseUrl: string, private router: Router, private route: ActivatedRoute,
    private authService: AuthService, 
  ) {
    this.baseUrl = baseUrl;
    this.showError = false;
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      userName: ['', [Validators.required]],
      password: ['', [Validators.required]]
    })
    
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
