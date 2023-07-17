import { Game } from '../GameEngine/Game';

import { NewGameRequest } from '../PrimaryPortRequest/NewGameRequest';
import { LauchGameRequest } from '../PrimaryPortRequest/LauchGameRequest';

import { IMPresenter } from 'CleanArchi/IMPresenter';
import { CreateGameUseCase } from '../UsesCases/CreateGameUseCase';
import { LauchGameUseCase } from '../UsesCases/LauchGameUseCase';

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
