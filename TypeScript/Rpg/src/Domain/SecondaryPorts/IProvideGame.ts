import { Game } from '../GameEngine/Game';

export interface IProvideGame {
  GetByGameId(gameId: string): PromiseLike<Game>;
  Add(game: Game): PromiseLike<void>;
  GetByPlayerId(playerId: string): PromiseLike<Game[]>;
}
