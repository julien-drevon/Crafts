import { UUID } from "crypto";

export function isOnError(error: CorrelationError | undefined | null): boolean {
  if (!error) return false;

  return error.isOnError();
}

export class CorrelationError {
  public isOnError(): boolean {
    return this._errors.length > 0;
  }
  getErrors(): string[] {
    return this._errors.slice();
  }

  addError(message: string) {
    this._errors.push(message);
  }

  constructor(correlationToken: UUID, errors: string[] = []) {
    this._CorrelationToken = correlationToken;
    this._errors = errors.slice();
  }

  private _errors: string[] = [];

  private _CorrelationToken: UUID;
  public get CorrelationToken(): UUID {
    return this._CorrelationToken;
  }
}
