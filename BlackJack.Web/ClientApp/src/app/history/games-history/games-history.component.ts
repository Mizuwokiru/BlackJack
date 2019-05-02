import { Component, OnInit } from '@angular/core';
import { HistoryService } from '../../shared/services/history.service';
import { GamesHistoryViewModel } from '../../shared/models/games-history.view-model';

@Component({
  selector: 'app-games-history',
  templateUrl: './games-history.component.html',
  styleUrls: ['./games-history.component.scss']
})
export class GamesHistoryComponent implements OnInit {
  private gamesHistory: GamesHistoryViewModel;

  public constructor(private historyService: HistoryService) { }

  public ngOnInit() {
    this.historyService.getGamesHistory()
      .subscribe(gamesHistory => this.gamesHistory = gamesHistory);
  }
}
