import { CorrelationError } from "./CorrelationError";

export interface IMInPresenter<TIn> {
  presentData(data: TIn);

  presentError(error: CorrelationError);
}
