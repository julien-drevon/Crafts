export interface IMOutPresenter<TOut> {
  View(): PromiseLike<TOut>;
}
