import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}
export function getApiBaseUrl() {
  return "https://localhost:7014/";
}
export function getOrgCode() {
  return "GL";
}

const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
  { provide: 'API_BASE_URL', useFactory: getApiBaseUrl, deps: [] },
  { provide: 'OrgCode', useFactory: getOrgCode, deps: [] }
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers).bootstrapModule(AppModule)
  .catch(err => console.log(err));
