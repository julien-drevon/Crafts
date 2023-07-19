import { Game } from 'Domain/GameEngine/Game';
import { GameAdapter } from '../../src/Domain/PrimaryDomainAdapter/GameAdapter';
import { Player } from '../../src/Domain/Player';
import { SimplePresenter } from '../../src/CleanArchi/SimplePresenter';
import { MoveInWorldGameProviderFake } from './Fakes/MoveInWorldGameProviderFake';

describe('StartNewGame', () => {
  it('GivenNewPlayer_AndIWantStartGame_ShouldReturnDefaultGame', async () => {
    const givenPlayer = new Player('moi');
    const gameAdapter = new GameAdapter(
      new SimplePresenter<Game>(),
      new MoveInWorldGameProviderFake()
    );

    const newGame = await gameAdapter.New({
      Player: givenPlayer
    });

    expect(newGame.Player).toEqual(givenPlayer);
    expect(newGame.World).not.toBeNull();
  });
});
