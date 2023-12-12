import { UUID } from 'crypto';
import { TypedError } from "./TypedError";


export class CorrelationError {
  getErrors(): TypedError[] {
    return this._errors.slice();   
  }

  addError(type: string, message: string) {
    this._errors.push(new TypedError(type, message));   
  }

  constructor(correlationToken: UUID, errors:TypedError[]=[]) {
    this._CorrelationToken = correlationToken;
    this._errors = errors.slice()
  }

  private _errors:TypedError[]=[];

  private _CorrelationToken: UUID;
  public get CorrelationToken(): UUID {
    return this._CorrelationToken;
  }
}

