import { UUID } from 'crypto';
import { Player } from '../Player';

export class LauchGameRequest {
  public GameId: UUID;
  public Player: Player;
}
