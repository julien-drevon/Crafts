import { GameAdapter } from '../../src/Domain/GameAdapter';
import { GameBuilder } from '../../src/Domain/GameBuilder';
import { Player } from '../../src/Domain/Player';

describe('StartNewGame', () => {
  it('GivenNewPlayer_AndIWantStartGame_ShouldReturnDefaultGame', async () => {
    const givenPlayer = new Player('moi');
    const gameAdapter = new GameAdapter();

    const newGame = await gameAdapter.New({
      Player: givenPlayer
    });

    expect(newGame).toEqual(new GameBuilder().Build());
  });
});
