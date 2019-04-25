import { RoundState } from '../enums/round-state.enum';

export interface PlayerGameViewModel {
  playerName: string;
  cards: Array<number>;
  state: RoundState;
  score: number;
}
