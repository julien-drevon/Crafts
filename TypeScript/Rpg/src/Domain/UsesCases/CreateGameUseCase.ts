import { IMUseCase } from 'CleanArchi/IMUseCase';
import { Game } from '../Game';
import { GameBuilder } from '../GameBuilder';
import { NewGameRequest } from '../NewGameRequest';
import { IMInPresenter } from 'CleanArchi/IMInPresenter';

export class CreateGameUseCase implements IMUseCase<NewGameRequest, Game> {
  async Execute(
    query: NewGameRequest,
    presenter: IMInPresenter<Game>
  ): Promise<void> {
    presenter.Present(new GameBuilder().AddPlayer(query.Player).Build());
  }
}
