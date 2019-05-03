import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { GameViewModel } from '../../shared/models/game.view-model';
import { HistoryService } from '../../shared/services/history.service';

@Component({
  selector: 'app-round',
  templateUrl: './round.component.html',
  styleUrls: ['./round.component.scss']
})
export class RoundComponent implements OnInit {
  private roundInfo: GameViewModel;

  public constructor(
    private historyService: HistoryService,
    private route: ActivatedRoute
  ) { }

  public ngOnInit() {
    const gameId: number = +this.route.snapshot.paramMap.get('gameId');
    const roundId: number = +this.route.snapshot.paramMap.get('roundId');
    this.historyService.getRoundInfo(gameId, roundId)
      .subscribe(roundInfo => this.roundInfo = roundInfo);
  }
}
