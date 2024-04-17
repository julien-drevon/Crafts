import { IMPresenter } from "../IMPresenter";
import { CorrelationError } from "../errors/CorrelationError";
import { PresentData } from "../PresentData";

export class SimplePresenter<TInOut> implements IMPresenter<TInOut, TInOut> {
  private _Datas: TInOut;
  private _Error: CorrelationError | undefined = undefined;
  presentData(data: TInOut) {
    this._Datas = data;
  }
  presentError(error: CorrelationError) {
    this._Error = error;
  }
  async view(): Promise<PresentData<TInOut>> {
    return { data: this._Datas, error: this._Error };
  }
}
