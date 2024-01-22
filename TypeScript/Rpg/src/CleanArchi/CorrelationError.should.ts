import { CorrelationError } from "./CorrelationError";
import {  randomUUID } from 'crypto';
import { TypedError } from "./TypedError";

describe("Core Error", () => {
  it("I want to add errors an error with a message and type", () => {
    
    const errors = new CorrelationError( randomUUID());
    expect(errors.CorrelationToken).toBeTruthy();
    expect(errors.CorrelationToken).not.toBe(randomUUID());
    expect(errors.getErrors()).toHaveLength(0);

    errors.addError("unType","uneErreur");

    expect(errors.getErrors()).toHaveLength(1);

    const errors2 = new CorrelationError(randomUUID(),[new TypedError("deuxiemType", "42!")]);

    expect(errors2.getErrors()).toHaveLength(1);
  });
});
