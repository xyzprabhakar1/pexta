import { enmMessageType } from './enums';

export interface mdlReturnData {
  messageType: enmMessageType;
  error: Error;
  message: string,
  returnId: any
}

