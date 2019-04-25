import { Component, OnInit } from '@angular/core';
import { HistoryService } from '../history.service';
import { GamesHistoryViewModel } from './games-history.view-model';

@Component({
  selector: 'app-games-history',
  templateUrl: './games-history.component.html',
  styleUrls: ['./games-history.component.scss']
})
export class GamesHistoryComponent implements OnInit {
  private gamesHistory: GamesHistoryViewModel;

  constructor(private historyService: HistoryService) { }

  ngOnInit() {
    this.historyService.getGamesHistory()
      .subscribe(gamesHistory => this.gamesHistory = gamesHistory);
  }

}
