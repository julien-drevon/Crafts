import { CorrelationError, isOnError } from "./CorrelationError";
import { randomUUID } from "crypto";

describe("Core Error", () => {
  it("I want to add errors an error with a message and type", () => {
    expect(isOnError(null)).toBe(false);
    expect(isOnError(undefined)).toBe(false);

    const errors = new CorrelationError(randomUUID());
    expect(errors.CorrelationToken).toBeTruthy();
    expect(errors.CorrelationToken).not.toBe(randomUUID());
    expect(errors.getErrors()).toHaveLength(0);
    expect(errors.isOnError()).toBe(false);
    expect(isOnError(errors)).toBe(false);

    errors.addError("uneErreur");
    expect(errors.getErrors()).toHaveLength(1);
    expect(errors.isOnError()).toBe(true);
    expect(isOnError(errors)).toBe(true);

    const errors2 = new CorrelationError(randomUUID(), ["42!"]);
    expect(errors2.getErrors()).toHaveLength(1);
  });
});
