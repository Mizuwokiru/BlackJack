import { Round } from './round.model';

export class RoundInfo {
  public user: Round;
  public bots: Array<Round>;
  public dealer: Round;
}
