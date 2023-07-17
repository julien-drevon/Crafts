import { Sprite, ISprite } from './Sprite';

export class World {
  constructor(me: Sprite) {
    this._Me = me;
  }
  private _Me: Sprite;
  get Me(): ISprite {
    return this._Me;
  }
}
