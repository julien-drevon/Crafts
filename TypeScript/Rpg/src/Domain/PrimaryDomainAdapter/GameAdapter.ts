import { Game } from '../GameEngine/Game';

import { NewGameRequest } from '../PrimaryPortRequest/NewGameRequest';
import { LauchGameRequest } from '../PrimaryPortRequest/LauchGameRequest';

import { IMPresenter } from 'CleanArchi/IMPresenter';
import { CreateGameUseCase } from '../UsesCases/CreateGameUseCase';
import { LauchGameUseCase } from '../UsesCases/LauchGameUseCase';
import { IProvideGame } from '../SecondaryPorts/IProvideGame';

export class GameAdapter<TOut> {
  constructor(
    private _GamePresenter: IMPresenter<Game, TOut>,
    private _GameProvide: IProvideGame
  ) {}

  async New(newGameRequest: NewGameRequest): Promise<TOut> {
    await new CreateGameUseCase(this._GameProvide).Execute(
      newGameRequest,
      this._GamePresenter
    );
    return await this._GamePresenter.View();
  }

  async Lauch(newGameRequest: LauchGameRequest): Promise<TOut> {
    await new LauchGameUseCase(this._GameProvide).Execute(
      newGameRequest,
      this._GamePresenter
    );
    return await this._GamePresenter.View();
  }
}
