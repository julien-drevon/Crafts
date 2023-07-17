import { IPoint } from './Point';

export class RealPoint implements IPoint {
  constructor(private _X: number = 0, private _Y: number = 0) {}
  get X(): number {
    return this._X;
  }
  get Y(): number {
    return this._Y;
  }
}