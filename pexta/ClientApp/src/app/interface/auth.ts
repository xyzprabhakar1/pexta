

export interface mdlError {
  errorId: number;
  message: string;
}

export interface mdlLoginRequest {
  userName: string;
  password: string;
}




export interface mdlLoginResponse {
  isSuccess: boolean;
  token: string;
  error: mdlError;
}
