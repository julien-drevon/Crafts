import { IMUseCase } from 'CleanArchi/IMUseCase';
import { Game } from '../GameEngine/Game';
import { LauchGameRequest } from '../PrimaryPortRequest/LauchGameRequest';
import { IMInPresenter } from 'CleanArchi/IMInPresenter';
import { GameBuilder } from '../GameBuilder';

export class LauchGameUseCase implements IMUseCase<LauchGameRequest, Game> {
  async Execute(
    query: LauchGameRequest,
    presenter: IMInPresenter<Game>
  ): Promise<void> {
    presenter.Present(new GameBuilder().AddPlayer(query.Player).Build());
  }
}
