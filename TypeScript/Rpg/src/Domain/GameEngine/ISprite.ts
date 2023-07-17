import { ISize } from './ISize';
import { IPoint } from './Point';

export interface ISprite {
  get Size(): ISize;
  get Origine(): IPoint;
  get Position(): IPoint;
}
