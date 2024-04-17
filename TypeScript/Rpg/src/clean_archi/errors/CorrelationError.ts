import { UUID } from "crypto";

export function isOnError(error: CorrelationError | undefined | null): boolean {
  if (!error) return false;

  return error.isOnError();
}
export function isNotOnError(
  error: CorrelationError | undefined | null
): boolean {
  return !isOnError(error);
}

export class CorrelationError {
  private _errors: string[] = [];
  private _CorrelationToken: UUID;

  constructor(correlationToken: UUID, errors: string[] = []) {
    this._CorrelationToken = correlationToken;
    this._errors = errors.slice();
  }

  public isOnError(): boolean {
    return this._errors.length > 0;
  }

  getErrors(): string[] {
    return this._errors.slice();
  }

  addError(message: string) {
    this._errors.push(message);
  }

  public get CorrelationToken(): UUID {
    return this._CorrelationToken;
  }
}
