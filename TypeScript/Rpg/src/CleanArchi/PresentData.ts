import { CorrelationError } from "./CorrelationError";

export class PresentData<Tout> {
  data: Tout;
  error: CorrelationError;
}
