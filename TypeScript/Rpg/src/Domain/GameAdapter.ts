import { IMUseCase } from 'CleanArchi/IMUseCase';
import { Game } from './Game';

import { LauchGameRequest, NewGameRequest } from './NewGameRequest';

import { IMInPresenter } from 'CleanArchi/IMInPresenter';
import { IMPresenter } from 'CleanArchi/IMPresenter';
import { CreateGameUseCase } from './UsesCases/CreateGameUseCase';
import { GameBuilder } from './GameBuilder';

export class GameAdapter<TOut> {
  constructor(private _Presenter: IMPresenter<Game, TOut>) {}

  async New(newGameRequest: NewGameRequest): Promise<TOut> {
    await new CreateGameUseCase().Execute(newGameRequest, this._Presenter);
    return await this._Presenter.View();
  }

  async Lauch(newGameRequest: LauchGameRequest): Promise<TOut> {
    await new LauchGameUseCase().Execute(newGameRequest, this._Presenter);
    return await this._Presenter.View();
  }
}

export class LauchGameUseCase implements IMUseCase<LauchGameRequest, Game> {
  async Execute(
    query: LauchGameRequest,
    presenter: IMInPresenter<Game>
  ): Promise<void> {
    presenter.Present(new GameBuilder().AddPlayer(query.Player).Build());
  }
}
