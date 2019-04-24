import { Component, OnInit } from '@angular/core';
import { RoundState } from '../../shared/enums/round-state.enum';
import { RoundsHistory } from './rounds-history';
import { HistoryService } from '../history.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-rounds-history',
  templateUrl: './rounds-history.component.html',
  styleUrls: ['./rounds-history.component.scss']
})
export class RoundsHistoryComponent implements OnInit {
  private roundsHistory: RoundsHistory;
  private gameId: number;

  readonly stateHelper: Map<RoundState, RoundStateInfo> = new Map<RoundState, RoundStateInfo>([
    [RoundState.None, {
      btnClass: 'light',
      text: 'Not finished'
    }],
    [RoundState.Won, {
      btnClass: 'success',
      text: 'Won'
    }],
    [RoundState.Lose, {
      btnClass: 'danger',
      text: 'Lose'
    }],
    [RoundState.Push, {
      btnClass: 'primary',
      text: 'Push'
    }]
  ]);

  constructor(
    private historyService: HistoryService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.gameId = +this.route.snapshot.paramMap.get('gameId');
    this.historyService.getRoundsHistory(this.gameId)
      .subscribe(rounds => this.roundsHistory = rounds);
  }
}

interface RoundStateInfo {
  btnClass: string;
  text: string;
}
