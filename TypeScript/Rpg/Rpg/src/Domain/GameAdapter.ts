import { GameBuilder } from './GameBuilder';
import { GameResult } from './GameResult';
import { NewGameRequest } from './NewGameRequest';

export class GameAdapter {
  async New(newGameRequest: NewGameRequest): Promise<GameResult> {
    return new GameBuilder().Build();
  }
}
