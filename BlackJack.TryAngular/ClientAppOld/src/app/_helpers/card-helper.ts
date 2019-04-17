import { Rank } from '../_enums/rank';
import { Card } from '../_models/card';

export class CardHelper {
    public static readonly BlankCard: number = 0x1F0A0;

    public static readonly BlackColor = "black";
    public static readonly RedColor = "darkred";

    public static getCardValue(card: Card): number {
        if (!card) {
            return CardHelper.BlankCard;
        }
        let cardValue: number = CardHelper.BlankCard + (card.suit - 1) * 0x10 + card.rank;
        if (card.rank >= Rank.Queen) {
            cardValue++;
        }
        return cardValue;
    }
}