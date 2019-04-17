import { Card } from '../_models/card.model';
import { Rank } from '../_enums/rank.enum';

export class CardHelper {
  public static readonly BlankCard: number = 0x1F0A0;

  public static readonly BlackColor: string = 'black';
  public static readonly RedColor: string = 'darkred';

  private static getCardValue(card: Card): number {
    if (!card) {
      return CardHelper.BlankCard;
    }
    let cardValue: number = CardHelper.BlankCard + (card.suit - 1) * 0x10 + card.rank;
    if (card.rank >= Rank.Queen) {
      cardValue++;
    }
    return cardValue;
  }

  public static getCardUnicode(card: Card) {
    return String.fromCodePoint(CardHelper.getCardValue(card));
  }
}
