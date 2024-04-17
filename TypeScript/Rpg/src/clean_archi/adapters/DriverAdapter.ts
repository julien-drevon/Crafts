import { CorrelationError, isOnError } from "../errors/CorrelationError";
import { IMUseCase } from "../IMUseCase";
import { IMPresenter } from "../IMPresenter";
import { PresentData } from "../PresentData";
import { IValidateRequest } from "../IValidateRequest";
import { IGotCorrelationToken } from "../IGotCorrelationToken";

export class DriverAdapter {
  public static async CreateUseCaseWorkflow<
    TOut,
    TUseCaseQuery extends IGotCorrelationToken,
    TUseCaseResult
  >(
    aRequestForDriverAdapter: IValidateRequest<TUseCaseQuery>,
    useCase: IMUseCase<TUseCaseQuery, TUseCaseResult>,
    presenter: IMPresenter<TUseCaseResult, TOut>
  ): Promise<PresentData<TOut>> {
    const query = aRequestForDriverAdapter.ValidateRequest();
    presenter.presentError(query[1]);

    if (isOnError(query[1]) === false) {
      await DriverAdapter.executeUseCase(
        useCase,
        query,
        presenter,
        aRequestForDriverAdapter
      );
    }

    return await presenter.view();
  }

  private static async executeUseCase<
    TOut,
    TUseCaseQuery extends IGotCorrelationToken,
    TUseCaseResult
  >(
    useCase: IMUseCase<TUseCaseQuery, TUseCaseResult>,
    query: [useCaseQuery: TUseCaseQuery, error: CorrelationError],
    presenter: IMPresenter<TUseCaseResult, TOut>,
    aRequestForDriverAdapter: IValidateRequest<TUseCaseQuery>
  ) {
    const useCaseQuery = query[0];
    try {
      await useCase.Execute(useCaseQuery, presenter);
    } catch (error) {
      presenter.presentError(
        new CorrelationError(aRequestForDriverAdapter.CorrelationToken, [
          error.message
        ])
      );
    }
  }
}
