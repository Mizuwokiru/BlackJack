import { Component, OnInit } from '@angular/core';
import { GameViewModel } from '../../shared/models/game.view-model';
import { HistoryService } from '../history.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-round',
  templateUrl: './round.component.html',
  styleUrls: ['./round.component.scss']
})
export class RoundComponent implements OnInit {
  private roundInfo: GameViewModel;

  constructor(
    private historyService: HistoryService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    const gameId: number = +this.route.snapshot.paramMap.get('gameId');
    const roundId: number = +this.route.snapshot.paramMap.get('roundId');
    this.historyService.getRoundInfo(gameId, roundId)
      .subscribe(roundInfo => this.roundInfo = roundInfo);
  }
}
