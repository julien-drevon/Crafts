import { Game } from 'Domain/Game';
import { GameAdapter } from '../../src/Domain/GameAdapter';
import { Player } from '../../src/Domain/Player';
import { SimplePresenter } from '../../src/CleanArchi/SimplePresenter';
import exp from 'constants';

describe('MoveInGrid', () => {
  it('GivenAGrid_WhenIStart_IShouldBeNoElementsInGrid', async () => {
    const givenGrid = new Grid();

    expect(givenGrid.count()).toBe(0);
  });

  it('GivenAGrid_ThenDefineANewElement_GridShouldHaveOjeelement', () => {
    const givenGrid = new Grid();
    const monSprite = new Sprite(0, 0);
    givenGrid.add(monSprite);

    expect(givenGrid.count()).toBe(1);
    expect(givenGrid.getSprite(0)).toBe(monSprite);
    expect(monSprite.getOrigine()).toEqual({ X: 0, Y: 0 });
  });
});

export class Sprite {
  private _Origine: RealPoint;
  getOrigine(): Point {
    return { X: this._Origine.X, Y: this._Origine.Y };
  }

  constructor(x: number, y: number) {
    this._Origine = new RealPoint(x, y);
  }
}

export class RealPoint implements Point {
  constructor(private _X: number = 0, private _Y: number = 0) {}
  get X(): number {
    return this._X;
  }
  get Y(): number {
    return this._Y;
  }
}

export interface Point {
  get X(): number;
  get Y(): number;
}

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
