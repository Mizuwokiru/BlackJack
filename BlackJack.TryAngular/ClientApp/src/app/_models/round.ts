import { PlayerType } from '../_enums/player.type';
import { Card } from './card';
import { RoundState } from '../_enums/round.state';

export class Round {
    playerName?: string;
    playerType?: PlayerType;
    cards?: Card[];
    state?: RoundState;
    score?: number;
    stringifiedCards?: string;
}