import { enmMessageType, enmUserType } from "./enums";


export interface mdlError {
  errorId: number;
  message: string;
}

export interface mdlLoginRequest {
  userName: string;
  password: string;  
  orgCode: string,
  captchaId: string,
  captchaValue: string,
  height: 40,
  width: 100,
  longitude: string,
  latitude: string
}




export interface mdlLoginResponse {
  messageType: enmMessageType;
  token: string;
  error: mdlError;
  userIdHex: string;
  orgId: number;
  normalizedName: string;
  failCount: number;
  userType: enmUserType;
  captchaId: string;
  captchaImages: any;
}
