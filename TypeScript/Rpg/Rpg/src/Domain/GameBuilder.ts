import { Game } from './Game';

export class GameBuilder {
  Build(): Game {
    return new Game();
  }
}
