import { Game } from 'Domain/GameEngine/Game';
import { IProvideGame } from 'Domain/SecondaryPorts/IProvideGame';

export class MoveInWorldGameProviderFake implements IProvideGame {
  async GetByGameId(gameId: string): Promise<Game> {
    return this._Game;
  }
  async GetByPlayerId(playerId: string): Promise<Game[]> {
    return [this._Game];
  }
  _Game: Game;
  async Add(game: Game): Promise<void> {
    this._Game = game;
  }
}
