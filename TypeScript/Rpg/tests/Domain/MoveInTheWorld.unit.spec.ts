import { Game } from 'Domain/GameEngine/Game';
import { GameAdapter } from '../../src/Domain/PrimaryDomainAdapter/GameAdapter';
import { Player } from '../../src/Domain/Player';
import { SimplePresenter } from '../../src/CleanArchi/SimplePresenter';
import { MoveInWorldGameProviderFake } from './Fakes/MoveInWorldGameProviderFake';
import { UUID, randomUUID } from 'crypto';

describe('MoveInTheWorld', () => {
  it('GivenNewPlayer_AndIWantStartGame_ShoulAppearInTheWorld', async () => {
    const givenPlayer = new Player('moi');
    const gameAdapter = new GameAdapter(
      new SimplePresenter<Game>(),
      new MoveInWorldGameProviderFake()
    );
    const newGame = await CreateNewGameAndLauch(givenPlayer, gameAdapter);

    expect(newGame.World.Me.Size.Largeur).toEqual(1);
    expect(newGame.World.Me.Size.Longueur).toEqual(1);
    expect(newGame.World.Me.Position).toEqual({ X: 0, Y: 0 });
    expect(newGame.World.Me.Origine).toEqual({ X: 0, Y: 0 });
  });

  it('GivenAPlayerInTheGame_WhenILauch_LEFT_Command_ThenShouldTranslateTo1OffX', async () => {
    const gameAdapter = new GameAdapter(
      new SimplePresenter<Game>(),
      new MoveInWorldGameProviderFake()
    );
    const newGame = await CreateNewGameAndLauch(new Player('moi'), gameAdapter);
    const gameStarted = await gameAdapter.ExecuteCommand(newGame.Id, 'LEFT');

    expect(gameStarted.World.Me.Position).toEqual({ X: 1, Y: 0 });
  });
});

async function CreateNewGameAndLauch(
  givenPlayer: Player,
  gameAdapter: GameAdapter<Game>
): Promise<Game> {
  const newGame = await gameAdapter.New({
    Player: givenPlayer
  });

  return await gameAdapter.Lauch({
    GameId: newGame.Id,
    Player: new Player('me')
  });
}
