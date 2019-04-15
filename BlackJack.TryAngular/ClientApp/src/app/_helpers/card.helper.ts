import { Rank } from '../_enums/rank';
import { Card } from '../_models/card';

export class CardHelper {
    public static readonly BlankCard: number = 0x1F0A0;

    public static readonly BlackColor = "black";
    public static readonly RedColor = "darkred";

    private static getCardValue(card: Card): number {
        let cardValue: number = this.BlankCard + (card.suit - 1) * 0x10 + card.rank;
        if (card.rank >= Rank.Queen) {
            cardValue++;
        }
        return cardValue;
    }

    private static getCardHtmlByValue(cardValue: number): string {
        let color = this.BlackColor;
        if ((cardValue > 0x1F0B0 && cardValue < 0x1F0D0) || cardValue == this.BlankCard) {
            color = this.RedColor;
        }
        return `<span style="color: ${color}">&#${cardValue};</span>`;
    }

    public static getCardHtml(card: Card): string {
        return this.getCardHtmlByValue(this.getCardValue(card));
    }

    public static getBlankCardHtml(): string {
        return this.getCardHtmlByValue(this.BlankCard);
    }

    public static getCardsHtml(cards: Card[]): string {
        let stringifiedCards = cards.map(this.getCardHtml).join('');
        if (cards.length == 1) {
            stringifiedCards += this.getBlankCardHtml();
        }
        return stringifiedCards;
    }
}