import { IMUseCase } from 'CleanArchi/IMUseCase';
import { Game } from './Game';
import { GameBuilder } from './GameBuilder';

import { NewGameRequest } from './NewGameRequest';

import { IMInPresenter } from 'CleanArchi/IMInPresenter';
import { IMPresenter } from 'CleanArchi/IMPresenter';

export class GameAdapter<TOut> {
  constructor(private _Presenter: IMPresenter<Game, TOut>) {}

  async New(newGameRequest: NewGameRequest): Promise<TOut> {
    await new CreateGameUseCase().Execute(newGameRequest, this._Presenter);
    return await this._Presenter.View();
  }
}

export class CreateGameUseCase implements IMUseCase<NewGameRequest, Game> {
  async Execute(
    query: NewGameRequest,
    presenter: IMInPresenter<Game>
  ): Promise<void> {
    presenter.Present(new GameBuilder().AddPlayer(query.Player).Build());
  }
}
