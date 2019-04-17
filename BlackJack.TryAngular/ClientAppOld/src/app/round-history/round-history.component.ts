import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HistoryService } from '../_services/history.service';
import { Round } from '../_models/round';
import { PlayerType } from '../_enums/player-type';

@Component({
  selector: 'app-round-history',
  templateUrl: './round-history.component.html',
  styleUrls: ['./round-history.component.scss']
})
export class RoundHistoryComponent implements OnInit {
  players: Round[] = [];
  dealer: Round;

  constructor(private route: ActivatedRoute,
    private historyService: HistoryService) { }

  ngOnInit() {
    const gameId: number = parseInt(this.route.snapshot.paramMap.get('gameId'));
    const roundId: number = parseInt(this.route.snapshot.paramMap.get('roundId'));
    this.historyService.getRoundInfo(gameId, roundId)
      .subscribe(players => {
        players.forEach(player => {
          if (player.playerType == PlayerType.Dealer) {
            this.dealer = player;
            return;
          }
          this.players.push(player);
        })
      });
  }

}
