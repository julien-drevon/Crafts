import { CorrelationError } from "./errors/CorrelationError";
import { UUID } from "crypto";
import { IGotCorrelationToken } from "./IGotCorrelationToken";

export interface IValidateRequest<TUseCaseQuery extends IGotCorrelationToken> {
  CorrelationToken: UUID;
  ValidateRequest(): [
    useCaseQuery: TUseCaseQuery,
    error: CorrelationError | null
  ];
}
