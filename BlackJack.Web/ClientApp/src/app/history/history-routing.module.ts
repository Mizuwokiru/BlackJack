import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GamesHistoryComponent } from './games-history/games-history.component';
import { RoundComponent } from './round/round.component';
import { RoundsHistoryComponent } from './rounds-history/rounds-history.component';

const routes: Routes = [
  {
    path: '',
    component: GamesHistoryComponent
  },
  {
    path: ':gameId',
    component: RoundsHistoryComponent
  },
  {
    path: ':gameId/:roundId',
    component: RoundComponent
  },
  {
    path: '**',
    redirectTo: ''
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HistoryRoutingModule { }
