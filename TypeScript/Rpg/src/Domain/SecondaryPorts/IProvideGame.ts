import { Game } from '../GameEngine/Game';

export interface IProvideGame {
  Add(game: Game): PromiseLike<void>;
  Get(playerId: string): PromiseLike<Game[]>;
}
