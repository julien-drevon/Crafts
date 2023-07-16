import { Sprite } from './Sprite';

export class Grid {
  constructor() {
    this._Elements = [];
  }

  getSprite(key: number): Sprite {
    return this._Elements[key];
  }
  add(sprite: Sprite) {
    this._Elements.push(sprite);
  }
  count(): number {
    return this._Elements.length;
  }
  private _Elements: Sprite[];
}
