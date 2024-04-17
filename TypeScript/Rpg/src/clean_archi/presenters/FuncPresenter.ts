import { CorrelationError } from "../errors/CorrelationError";
import { IMPresenter } from "../IMPresenter";
import { PresentData } from "../PresentData";

export class FuncPresenter<Tin, Tout> implements IMPresenter<Tin, Tout> {
  private _data: Tin;
  private _error: CorrelationError;

  constructor(public convertFunc: (toTransform: Tin) => PromiseLike<Tout>) {}

  presentData(data: Tin) {
    this._data = data;
  }

  presentError(error: CorrelationError) {
    this._error = error;
  }

  async view(): Promise<PresentData<Tout>> {
    return { data: await this.convertFunc(this._data), error: this._error };
  }
}
