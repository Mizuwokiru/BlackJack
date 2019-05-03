import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { GamesHistoryComponent } from './games-history/games-history.component';
import { HistoryRoutingModule } from './history-routing.module';
import { RoundComponent } from './round/round.component';
import { RoundsHistoryComponent } from './rounds-history/rounds-history.component';

@NgModule({
  declarations: [GamesHistoryComponent, RoundsHistoryComponent, RoundComponent],
  imports: [
    CommonModule,
    SharedModule,
    HistoryRoutingModule
  ]
})
export class HistoryModule { }
