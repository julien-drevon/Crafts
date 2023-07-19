import { Player } from '../Player';
import { World } from './World';
import { UUID } from 'crypto';
import { Sprite } from './Sprite';
export class Game {
  _World: World;
  Id: UUID;
  constructor(private _Player: Player) {
    this._World = new World(new Sprite(0, 0, 1, 1, 0, 0));
  }
  get Player(): Player {
    return this._Player;
  }
  get World(): World {
    return this._World;
  }
}
