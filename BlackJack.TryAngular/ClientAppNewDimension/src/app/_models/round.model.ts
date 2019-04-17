import { PlayerType } from '../_enums/player-type.enum';
import { Card } from './card.model';
import { RoundState } from '../_enums/round-state.enum';

export class Round {
  public playerName: string;
  public playerType: PlayerType;
  public cards: Array<Card>;
  public state: RoundState;
  public score: number;
}
