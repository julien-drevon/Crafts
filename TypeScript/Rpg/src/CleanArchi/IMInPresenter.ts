import { CorrelationError } from "./CorrelationError";

export interface IMInPresenter<TIn> {
  PresentData(data: TIn);

  PresentError( error:CorrelationError)
}


