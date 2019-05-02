import { Component, OnInit } from '@angular/core';
import { RoundState } from '../../shared/enums/round-state.enum';
import { RoundsHistoryViewModel } from '../../shared/models/rounds-history.view-model';
import { HistoryService } from '../../shared/services/history.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-rounds-history',
  templateUrl: './rounds-history.component.html',
  styleUrls: ['./rounds-history.component.scss']
})
export class RoundsHistoryComponent implements OnInit {
  private roundsHistory: RoundsHistoryViewModel;
  private gameId: number;

  private readonly stateHelper: Map<RoundState, RoundStateInfo> = new Map<RoundState, RoundStateInfo>([
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

  public constructor(
    private historyService: HistoryService,
    private route: ActivatedRoute
  ) { }

  public ngOnInit() {
    this.gameId = +this.route.snapshot.paramMap.get('gameId');
    this.historyService.getRoundsHistory(this.gameId)
      .subscribe(rounds => this.roundsHistory = rounds);
  }
}

interface RoundStateInfo {
  btnClass: string;
  text: string;
}
