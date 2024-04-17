import { CorrelationError } from "./errors/CorrelationError";

export interface IMInPresenter<TIn> {
  presentData(data: TIn);

  presentError(error: CorrelationError);
}
