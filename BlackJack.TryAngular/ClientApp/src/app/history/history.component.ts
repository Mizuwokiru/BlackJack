import { Component, OnInit } from '@angular/core';
import { HistoryGame } from '../_models/history-game.model';
import { HistoryService } from '../_services/history.service';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss']
})
export class HistoryComponent implements OnInit {
  historyGames: Array<HistoryGame>;

  constructor(private historyService: HistoryService) { }

  ngOnInit() {
    this.historyService.getGames()
      .subscribe(games => this.historyGames = games);
  }

}
