import { Sprite } from './Sprite';
import { ISprite } from './ISprite';

export class World {
  ExecuteCommand(command: string) {
    this._Me.TranslateTo(1);
  }
  constructor(me: Sprite) {
    this._Me = me;
  }
  private _Me: Sprite;
  get Me(): ISprite {
    return this._Me;
  }
}
