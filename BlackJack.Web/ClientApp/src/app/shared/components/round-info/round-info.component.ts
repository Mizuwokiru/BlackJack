import { Component, Input, OnInit } from '@angular/core';
import { RoundInfo } from '../../models/round-info';
import { Player } from '../../models/player';

@Component({
  selector: 'app-round-info',
  templateUrl: './round-info.component.html',
  styleUrls: ['./round-info.component.scss']
})
export class RoundInfoComponent implements OnInit {
  @Input() roundInfo: RoundInfo;

  players: Array<Player>;
  dealer: Player;

  ngOnInit() {
      this.players = this.roundInfo.players;
      this.dealer = this.players.pop();
  }

}
