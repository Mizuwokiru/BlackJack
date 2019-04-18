import { Component, Input, OnInit } from '@angular/core';
import { Card } from '../_models/card.model';
import { CardHelper } from '../_helpers/card-helper.helper';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {
  @Input() card: Card;

  cardColor: string;
  cardString: string;

  ngOnInit() {
    const cardValue: number = CardHelper.getCardValue(this.card);
    this.cardString = String.fromCodePoint(cardValue);
    this.cardColor = CardHelper.BlackColor;
    if ((cardValue > 0x1F0B0 && cardValue < 0x1F0D0) || cardValue == CardHelper.BlankCard) {
      this.cardColor = CardHelper.RedColor;
    }
  }

}
