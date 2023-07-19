import { Game } from '../GameEngine/Game';

import { NewGameRequest } from '../PrimaryPortRequest/NewGameRequest';
import { LauchGameRequest } from '../PrimaryPortRequest/LauchGameRequest';

import { IMPresenter } from 'CleanArchi/IMPresenter';
import { CreateGameUseCase } from '../UsesCases/CreateGameUseCase';
import { LauchGameUseCase } from '../UsesCases/LauchGameUseCase';
import { IProvideGame } from '../SecondaryPorts/IProvideGame';
import { UUID } from 'crypto';

export class GameAdapter<TOut> {
  async ExecuteCommand(gameId: UUID, command: string): Promise<TOut> {
    const game = await this._GameProvide.GetByGameId(gameId);
    game.World.ExecuteCommand(command);
    this._GamePresenter.Present(game);
    return await this._GamePresenter.View();
  }
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
