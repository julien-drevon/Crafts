import { IMUseCase } from 'CleanArchi/IMUseCase';
import { Game } from '../GameEngine/Game';
import { GameBuilder } from '../GameBuilder';
import { NewGameRequest } from '../PrimaryPortRequest/NewGameRequest';
import { IMInPresenter } from 'CleanArchi/IMInPresenter';
import { IProvideGame } from 'Domain/SecondaryPorts/IProvideGame';

export class CreateGameUseCase implements IMUseCase<NewGameRequest, Game> {
  constructor(private _GameProvider: IProvideGame) {}

  async Execute(
    query: NewGameRequest,
    presenter: IMInPresenter<Game>
  ): Promise<void> {
    const game = new GameBuilder().AddPlayer(query.Player).Build();
    await this._GameProvider.Add(game);
    presenter.Present(game);
  }
}
