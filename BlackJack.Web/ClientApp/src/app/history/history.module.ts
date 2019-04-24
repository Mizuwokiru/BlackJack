import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HistoryRoutingModule } from './history-routing.module';
import { GamesHistoryComponent } from './games-history/games-history.component';
import { RoundsHistoryComponent } from './rounds-history/rounds-history.component';
import { RoundComponent } from './round/round.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [GamesHistoryComponent, RoundsHistoryComponent, RoundComponent],
  imports: [
    CommonModule,
    SharedModule,
    HistoryRoutingModule
  ]
})
export class HistoryModule { }
