import { Component, OnInit } from '@angular/core';
import { Game } from '../_models/game';
import { HistoryService } from '../_services/history.service';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss']
})
export class HistoryComponent implements OnInit {
  games: Game[];

  constructor(private historyService: HistoryService) { }

  ngOnInit() {
    this.historyService.getGames()
      .subscribe(games => this.games = games);
  }
}
