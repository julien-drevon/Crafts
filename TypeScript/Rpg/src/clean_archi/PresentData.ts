import { CorrelationError } from "./errors/CorrelationError";

export class PresentData<Tout> {
  data: Tout;
  error: CorrelationError;
}
