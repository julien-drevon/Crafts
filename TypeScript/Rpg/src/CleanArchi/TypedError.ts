export class TypedError {
  public get message(): string {
    return this._message;
  }

  public get type(): string {
    return this._type;
  }

  constructor(private _type: string, private _message: string) {}
}
