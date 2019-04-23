import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HistoryRoutingModule } from './history-routing.module';
import { GamesHistoryComponent } from './games-history/games-history.component';
import { RoundsHistoryComponent } from './rounds-history/rounds-history.component';
import { RoundComponent } from './round/round.component';

@NgModule({
  declarations: [GamesHistoryComponent, RoundsHistoryComponent, RoundComponent],
  imports: [
    CommonModule,
    HistoryRoutingModule
  ]
})
export class HistoryModule { }
