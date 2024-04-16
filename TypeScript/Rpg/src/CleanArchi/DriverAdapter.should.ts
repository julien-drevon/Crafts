import { CorrelationError } from "./CorrelationError";
import { randomUUID, UUID } from "crypto";
import { IMUseCase } from "./IMUseCase";
import { IMInPresenter } from "./IMInPresenter";
import { SimplePresenter } from "./SimplePresenter";
import { DriverAdapter } from "./DriverAdapter";
import { IGotCorrelationToken } from "./IGotCorrelationToken";
import { IValidateRequest } from "./IValidateRequest";

describe("Core Error", () => {
  it("En tant que dev je souhaite exprimer un useCase à travers une fonction simplement et qu'il me retourne un cas valide", async () => {
    const presenter = new SimplePresenter<ExempleUseCaseResult>();
    const correlationtoken = randomUUID();
    const maRequest = await DriverAdapter.CreateUseCaseWorkflow(
      new ExempleDriverRequest(correlationtoken, "la question?"),
      new MonExempleUseCase(),
      presenter
    );

    expect(maRequest).toEqual({
      data: { correlationToken: correlationtoken, reponse: "42" },
      error: undefined
    });
  });

  it("En tant que dev je souhaite exprimer un useCase avec une erreur de formatage de la query à travers une fonction simplement et qu'il me retorune un message d'erreur", async () => {
    const presenter = new SimplePresenter<ExempleUseCaseResult>();
    const correlationtoken = randomUUID();
    const maRequest = await DriverAdapter.CreateUseCaseWorkflow(
      new ExempleDriverRequest(correlationtoken, ""),
      new MonExempleUseCase(),
      presenter
    );

    expect(maRequest).toEqual({
      data: undefined,
      error: new CorrelationError(correlationtoken, [
        "la question ne peut être vide"
      ])
    });
  });

  it("En tant que dev je souhaite exprimer un useCase avec une erreur metier qui propage une exception à travers une fonction simplement et qu'il me retorune un message d'erreur", async () => {
    const presenter = new SimplePresenter<ExempleUseCaseResult>();
    const correlationtoken = randomUUID();
    const maRequest = await DriverAdapter.CreateUseCaseWorkflow(
      new ExempleDriverRequest(correlationtoken, "un truc"),
      new MonExempleUseCase(),
      presenter
    );

    expect(maRequest).toEqual({
      data: undefined,
      error: new CorrelationError(correlationtoken, [
        "on doit poser LA QUESTION"
      ])
    });
  });
});

export class ExempleDriverRequest
  implements IValidateRequest<ExempleUseCaseQuery>
{
  constructor(public CorrelationToken: UUID, public question: string) {}

  ValidateRequest(): [
    useCaseQuery: ExempleUseCaseQuery,
    error: CorrelationError | undefined
  ] {
    if (!this.question || this.question === "") {
      return [
        undefined,
        new CorrelationError(this.CorrelationToken, [
          "la question ne peut être vide"
        ])
      ];
    }
    return [
      new ExempleUseCaseQuery(this.CorrelationToken, this.question),
      undefined
    ];
  }
}

export class ExempleUseCaseQuery implements IGotCorrelationToken {
  constructor(public correlationToken: UUID, public question: string) {}
}

export class ExempleUseCaseResult implements IGotCorrelationToken {
  constructor(public correlationToken: UUID, public reponse: string) {}
}

export class MonExempleUseCase
  implements IMUseCase<ExempleUseCaseQuery, ExempleUseCaseResult>
{
  async Execute(
    query: ExempleUseCaseQuery,
    presenter: IMInPresenter<ExempleUseCaseResult>
  ): Promise<void> {
    if (query.question !== "la question?") {
      throw new Error("on doit poser LA QUESTION");
    }

    presenter.presentData(
      new ExempleUseCaseResult(query.correlationToken, "42")
    );
  }
}
