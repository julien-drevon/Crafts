import { IMPresenter } from './IMPresenter';
import { CorrelationError } from './CorrelationError';
import { PresentData } from "./PresentData";

export class SimplePresenter<TInOut> implements IMPresenter<TInOut, TInOut> {
  private _Datas:TInOut 
  private _Error:CorrelationError|undefined;
  PresentData(data: TInOut) {
    this._Datas=data;
  }
  PresentError(error: CorrelationError) {
    this._Error = error;
  }
  async View(): Promise<PresentData<TInOut>> {
    return {data:this._Datas, error:this._Error};
  }
}
