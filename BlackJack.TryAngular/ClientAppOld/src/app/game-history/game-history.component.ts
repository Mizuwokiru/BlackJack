import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { HistoryService } from '../_services/history.service';
import { GameInfo } from '../_models/game-info';

@Component({
  selector: 'app-game-history',
  templateUrl: './game-history.component.html',
  styleUrls: ['./game-history.component.scss']
})
export class GameHistoryComponent implements OnInit {
  gameId: number;
  gameInfo?: GameInfo;
  isLoaded: boolean;

  constructor(private route: ActivatedRoute,
    private historyService: HistoryService) { }

  ngOnInit() {
    this.gameId = parseInt(this.route.snapshot.paramMap.get('gameId'));
    this.historyService.getGameInfo(this.gameId)
      .subscribe(gameInfo => this.gameInfo = gameInfo);
  }

}
