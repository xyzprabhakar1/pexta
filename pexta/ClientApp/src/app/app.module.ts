import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AuthService } from './services/auth.service'

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { NavSidemenuComponent } from './nav-sidemenu/nav-sidemenu.component';
import { LoginComponent } from './login/login.component';
import { ForgetPasswordComponent } from './login/forget-password.component';
import { ResetPasswordComponent } from './login/reset-password.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    NavSidemenuComponent,
    LoginComponent,
    ForgetPasswordComponent,
    ResetPasswordComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'login', component: LoginComponent },
      { path: 'forget-password', component: ForgetPasswordComponent },
      { path: 'reset-password', component: ResetPasswordComponent },
      { path: 'hrms', loadChildren: () => import('./hrms/hrms.module').then(m => m.HrmsModule) },
      { path: 'crm', loadChildren: () => import('./crm/crm.module').then(m => m.CRMModule) },
      { path: 'srm', loadChildren: () => import('./srm/srm.module').then(m => m.SRMModule) },
      { path: 'pos', loadChildren: () => import('./pos/pos.module').then(m => m.POSModule) },
      { path: 'ets', loadChildren: () => import('./ets/ets.module').then(m => m.ETSModule) },
      { path: 'asset-management', loadChildren: () => import('./asset-management/asset-management.module').then(m => m.AssetManagementModule) },
    ])
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
 
})
export class AppModule { }
