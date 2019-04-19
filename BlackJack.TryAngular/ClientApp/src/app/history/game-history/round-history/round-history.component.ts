import { Component, OnInit } from '@angular/core';
import { RoundInfo } from '../../../_models/round-info.model';
import { HistoryService } from '../../../_services/history.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-round-history',
  templateUrl: './round-history.component.html',
  styleUrls: ['./round-history.component.scss']
})
export class RoundHistoryComponent implements OnInit {
  roundInfo: RoundInfo;

  constructor(
    private historyService: HistoryService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    const gameId: number = parseInt(this.route.snapshot.paramMap.get('gameId'));
    const roundId: number = parseInt(this.route.snapshot.paramMap.get('roundId'));
    this.historyService.getRoundInfo(gameId, roundId)
      .subscribe(roundInfo => this.roundInfo = roundInfo);
  }

}
