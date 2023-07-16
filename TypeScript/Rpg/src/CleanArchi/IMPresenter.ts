import { IMInPresenter } from './IMInPresenter';
import { IMOutPresenter } from './IMOutPresenter';

export interface IMPresenter<TIn, TOut>
  extends IMInPresenter<TIn>,
    IMOutPresenter<TOut> {}
