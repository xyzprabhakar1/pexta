export interface Applications {
  id: number;
  name: string;
  url: string;
  apiBaseUrl: string;
  modules: Array<Modules>;
  havePermission: boolean;
}

export interface Modules {
  id: number;
  name: string;
  url: string;  
  applicationId: number;
  subModules: Array<SubModules>;
  forms: Array<Forms>;
  havePermission: boolean;
}

export interface SubModules {
  id: number;
  name: string;
  url: string;  
  moduleId: number;
  forms: Array<Forms>;
  havePermission: boolean;
}

export interface Forms {
  id: number;
  name: string;
  url: string;  
  moduleId: number;
  subModuleId: number;
  havePermission: boolean;
}

export interface claims {
  id: number;
  name: string;
  moduleId: number;
  subModuleId: number;
  formId: number;
  category: string;
  havePermission: boolean;
}
