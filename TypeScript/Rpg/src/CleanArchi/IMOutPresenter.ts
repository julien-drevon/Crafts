import { PresentData } from "./PresentData";

export interface IMOutPresenter<TOut> {
  View(): PromiseLike<PresentData<TOut>>;
}


