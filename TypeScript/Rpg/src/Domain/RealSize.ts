import { ISize } from './ISize';

export class RealSize implements ISize {
  constructor(private _Longueur = 0, private _Largeur = 0) {}
  get Longeur(): number {
    return this._Longueur;
  }
  get Largeur(): number {
    return this._Largeur;
  }
}
