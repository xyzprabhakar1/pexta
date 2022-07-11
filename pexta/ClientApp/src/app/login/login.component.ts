import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder } from "@angular/forms"
import { HttpClient } from "@angular/common/http"
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm !: FormGroup;
  public baseUrl: string;
  constructor(private formBuilder: FormBuilder, private http: HttpClient, @Inject('API_BASE_URL') baseUrl: string, private router:Router) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      userName: [''],
      password: ['']
    })
  }
  login() {
    this.http.post<any>(this.baseUrl + 'api/user/login', this.loginForm.value)
      .subscribe(res => {
        this.router.navigate(['dashboard'])
      }, err => {
        alert("something went wrong");
      }
      );
  }

}
