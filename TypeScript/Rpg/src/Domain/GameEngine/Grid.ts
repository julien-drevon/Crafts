import { Sprite, ISprite } from './Sprite';

export class Grid {
  constructor() {
    this._Elements = [];
  }

  getSprite(key: number): ISprite {
    return this._Elements[key];
  }
  add(sprite: ISprite) {
    this._Elements.push(sprite);
  }
  count(): number {
    return this._Elements.length;
  }
  private _Elements: ISprite[];
}
