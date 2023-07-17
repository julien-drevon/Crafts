import { ISize } from './ISize';
import { IPoint } from './Point';
import { RealPoint } from './RealPoint';
import { RealSize } from './RealSize';

export interface ISprite {
  get Size(): ISize;
  get Origine(): IPoint;
  get Position(): IPoint;
}

export class Sprite implements ISprite {
  private _Size: RealSize;
  private _Origine: RealPoint;
  private _Position: RealPoint;

  get Size(): ISize {
    return { Longueur: this._Size.Longueur, Largeur: this._Size.Largeur };
  }

  get Origine(): IPoint {
    return { X: this._Origine.X, Y: this._Origine.Y };
  }

  get Position(): IPoint {
    return { X: this._Position.X, Y: this._Position.Y };
  }

  constructor(x = 0, y = 0, longueur = 0, largeur = 0, posX = 0, posy = 0) {
    this._Origine = new RealPoint(x, y);
    this._Size = new RealSize(longueur, largeur);
    this._Position = new RealPoint(posX, posy);
  }
}
