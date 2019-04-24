import { Component, Input, OnInit } from '@angular/core';

const black = '#000000';
const red = '#B94442';

const blankCard = 0x1F0A0;
const heartsSuit = 0x1F0B0;
const cubesSuit = 0x1F0D0;

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {
  @Input() card: number;

  private cardColor: string;
  private cardValue: string;

  constructor() { }

  ngOnInit() {
    this.cardValue = String.fromCodePoint(this.card);
    this.cardColor = black;
    if ((this.card > heartsSuit && this.card < cubesSuit) || this.card === blankCard) {
      this.cardColor = red;
    }
  }

}
