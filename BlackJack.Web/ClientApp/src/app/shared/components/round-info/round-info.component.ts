import { Component, Input, OnInit } from '@angular/core';
import { GameViewModel } from '../../models/game.view-model';
import { PlayerGameViewModel } from '../../models/player-game.view-model';

@Component({
  selector: 'app-round-info',
  templateUrl: './round-info.component.html',
  styleUrls: ['./round-info.component.scss']
})
export class RoundInfoComponent implements OnInit {
  @Input() roundInfo: GameViewModel;

  players: Array<PlayerGameViewModel>;
  dealer: PlayerGameViewModel;

  ngOnInit() {
      this.players = this.roundInfo.players;
      this.dealer = this.players.pop();
  }

}
