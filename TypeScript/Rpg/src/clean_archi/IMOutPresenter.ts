import { PresentData } from "./PresentData";

export interface IMOutPresenter<TOut> {
  view(): PromiseLike<PresentData<TOut | undefined>>;
}
