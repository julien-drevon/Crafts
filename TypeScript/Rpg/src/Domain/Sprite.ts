import { ISize } from './ISize';
import { Point } from './Point';
import { RealPoint } from './RealPoint';
import { RealSize } from './RealSize';

export class Sprite {
  private _Size: RealSize;
  private _Origine: RealPoint;

  get Size(): ISize {
    return { Longeur: this._Size.Longeur, Largeur: this._Size.Largeur };
  }

  get Origine(): Point {
    return { X: this._Origine.X, Y: this._Origine.Y };
  }

  constructor(x = 0, y = 0, longuer = 0, largeur = 0) {
    this._Origine = new RealPoint(x, y);
    this._Size = new RealSize(longuer, largeur);
  }
}
