import { Component, OnInit } from '@angular/core';
import { HistoryService } from '../history.service';
import { GamesHistory } from './games-history';

@Component({
  selector: 'app-games-history',
  templateUrl: './games-history.component.html',
  styleUrls: ['./games-history.component.scss']
})
export class GamesHistoryComponent implements OnInit {
  private gamesHistory: GamesHistory;

  constructor(private historyService: HistoryService) { }

  ngOnInit() {
    this.historyService.getGamesHistory()
      .subscribe(gamesHistory => this.gamesHistory = gamesHistory);
  }

}
