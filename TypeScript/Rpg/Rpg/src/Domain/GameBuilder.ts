import { Game } from './Game';
import { Player } from './Player';

export class GameBuilder {
  private _Player: Player;
  AddPlayer(player: Player): GameBuilder {
    this._Player = player;
    return this;
  }
  Build(): Game {
    return new Game(this._Player);
  }
}
