import { randomUUID } from "crypto";
import { CorrelationError } from "../errors/CorrelationError";
import { SimplePresenter } from "./SimplePresenter";
import { FuncPresenter } from "./FuncPresenter";

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

describe("FuncPresenter", () => {
  it("I want to present datas and errors", async () => {
    const presenter = new FuncPresenter<TestDummy, string>(
      async (toTransform) => (toTransform ? toTransform.test : undefined)
    );
    const monAssertion = new TestDummy("42");
    const monErreur = new CorrelationError(randomUUID());

    expect(await presenter.view()).toEqual({
      data: undefined,
      error: undefined
    });

    presenter.presentData(monAssertion);
    expect(await presenter.view()).toEqual({
      data: "42",
      error: undefined
    });

    presenter.presentError(monErreur);
    expect(await presenter.view()).toEqual({
      data: "42",
      error: monErreur
    });
  });
});

class TestDummy {
  constructor(public test: string) {}
}
