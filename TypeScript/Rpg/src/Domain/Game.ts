import { Player } from './Player';
import { World } from './World';
export class Game {
  _World: World;
  constructor(private _Player: Player) {
    this._World = new World();
  }
  get Player(): Player {
    return this._Player;
  }
  get World(): World {
    return this._World;
  }
}
