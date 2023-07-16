import { IMPresenter } from './IMPresenter';

export class SimplePresenter<TInOut> implements IMPresenter<TInOut, TInOut> {
  async View(): Promise<TInOut> {
    return this._Data;
  }
  private _Data: TInOut;

  Present(data: TInOut) {
    this._Data = data;
  }
}
