import { Grid } from '../../src/Domain/Grid';
import { Sprite } from '../../src/Domain/Sprite';

describe('PlaceInGrid', () => {
  it('GivenAGrid_WhenIStart_IShouldBeNoElementsInGrid', async () => {
    const givenGrid = new Grid();

    expect(givenGrid.count()).toBe(0);
  });

  it('GivenAGrid_ThenDefineANewElementInOroigine_ThenShouldHaveOneElementInOrigin', () => {
    const givenGrid = new Grid();
    const monSprite = new Sprite(0, 0);
    givenGrid.add(monSprite);

    expect(givenGrid.count()).toBe(1);
    expect(givenGrid.getSprite(0)).toBe(monSprite);
    expect(monSprite.Origine).toEqual({ X: 0, Y: 0 });
  });

  it('GivenAGrid_ThenDefineA2ElementsAtDifferentsPositions_GridShouldHaveTwoElementsInDiverPosition', () => {
    const givenGrid = new Grid();
    const monPremierSprite = new Sprite(2, 3);
    const monSecondSprite = new Sprite(7, 8);

    givenGrid.add(monPremierSprite);
    givenGrid.add(monSecondSprite);

    expect(givenGrid.count()).toBe(2);
    expect(givenGrid.getSprite(0)).toBe(monPremierSprite);
    expect(givenGrid.getSprite(1)).toBe(monSecondSprite);

    expect(monPremierSprite.Origine).toEqual({ X: 2, Y: 3 });
    expect(monSecondSprite.Origine).toEqual({ X: 7, Y: 8 });
  });

  it('GivenAGrid_ThenDefineANewElementInOroigine_ThenShouldHaveASize', () => {
    const givenGrid = new Grid();
    const monSprite = new Sprite(0, 0, 5, 3);
    givenGrid.add(monSprite);

    expect(monSprite.Size.Longeur).toBe(5);
    expect(monSprite.Size.Largeur).toBe(3);
  });
});
