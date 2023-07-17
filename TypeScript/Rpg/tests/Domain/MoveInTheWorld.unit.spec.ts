import { Game } from 'Domain/GameEngine/Game';
import { GameAdapter } from '../../src/Domain/PrimaryDomainAdapter/GameAdapter';
import { Player } from '../../src/Domain/Player';
import { SimplePresenter } from '../../src/CleanArchi/SimplePresenter';

describe('AddAndMoveInTheWorld', () => {
  it('GivenNewPlayer_AndIWantStartGame_ShoulAppearInTheWorld', async () => {
    const givenPlayer = new Player('moi');
    const gameAdapter = new GameAdapter(new SimplePresenter<Game>());

    const newGame = await gameAdapter.New({
      Player: givenPlayer
    });

    const givenGame = await gameAdapter.Lauch({
      GameId: newGame.Id,
      Player: new Player('me')
    });

    expect(givenGame.World.Me.Size.Largeur).toEqual(1);
    expect(givenGame.World.Me.Size.Longueur).toEqual(1);
    expect(givenGame.World.Me.Position).toEqual({ X: 0, Y: 0 });
    expect(givenGame.World.Me.Origine).toEqual({ X: 0, Y: 0 });
  });
});
