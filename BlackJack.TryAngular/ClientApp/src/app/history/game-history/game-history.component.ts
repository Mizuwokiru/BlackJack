import { Component, OnInit } from '@angular/core';
import { HistoryRounds } from '../../_models/history-rounds.model';
import { RoundState } from '../../_enums/round-state.enum';
import { HistoryService } from '../../_services/history.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-game-history',
  templateUrl: './game-history.component.html',
  styleUrls: ['./game-history.component.scss']
})
export class GameHistoryComponent implements OnInit {
  historyRounds: HistoryRounds;
  gameId: number;

  readonly roundStates: Map<RoundState, RoundStateInfo> = new Map<RoundState, RoundStateInfo>([
    [RoundState.None, {
      btnClass: "light",
      text: "Not finished"
    }],
    [RoundState.Won, {
      btnClass: "success",
      text: "Won"
    }],
    [RoundState.Lose, {
      btnClass: "danger",
      text: "Lose"
    }],
    [RoundState.Push, {
      btnClass: "primary",
      text: "Push"
    }]
  ]);

  constructor(
    private historyService: HistoryService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.gameId = parseInt(this.route.snapshot.paramMap.get('gameId'));
    this.historyService.getRounds(this.gameId)
      .subscribe(rounds => this.historyRounds = rounds);
  }
}

interface RoundStateInfo {
  btnClass: string;
  text: string;
}
