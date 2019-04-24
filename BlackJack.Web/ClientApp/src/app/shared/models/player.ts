import { RoundState } from '../enums/round-state.enum';

export class Player {
  public playerName: string;
  public cards: Array<number>;
  public state: RoundState;
  public score: number;
}
