import { Player } from './Player';
export class Game {
  constructor(private _Player: Player) {}
  get Player(): Player {
    return this._Player;
  }
}
