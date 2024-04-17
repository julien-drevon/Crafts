import { UUID } from "crypto";

export interface IGotCorrelationToken {
  correlationToken: UUID;
}
