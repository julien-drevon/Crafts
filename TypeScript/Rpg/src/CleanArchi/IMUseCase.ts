import { IMInPresenter } from "./IMInPresenter";

export interface IMUseCase<TQuery, TUseCaseReturn> {
  Execute(
    query: TQuery,
    presenter: IMInPresenter<TUseCaseReturn>
  ): PromiseLike<void>;
}
