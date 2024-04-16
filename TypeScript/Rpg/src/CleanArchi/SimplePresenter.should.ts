import { randomUUID } from "crypto";
import { CorrelationError } from "./CorrelationError";
import { SimplePresenter } from "./SimplePresenter";

describe("SimplePresenter", () => {
  it("I want to present datas and errors", async () => {
    const presenter = new SimplePresenter<TestDummy>();
    const monAssertion = new TestDummy("42");
    const monErreur = new CorrelationError(randomUUID());

    expect(await presenter.view()).toEqual({
      data: undefined,
      error: undefined
    });

    presenter.presentData(monAssertion);
    expect(await presenter.view()).toEqual({
      data: monAssertion,
      error: undefined
    });

    presenter.presentError(monErreur);
    expect(await presenter.view()).toEqual({
      data: monAssertion,
      error: monErreur
    });
  });
});

class TestDummy {
  constructor(public test: string) {}
}
