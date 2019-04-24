import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GamesHistoryComponent } from './games-history/games-history.component';
import { RoundsHistoryComponent } from './rounds-history/rounds-history.component';
import { RoundComponent } from './round/round.component';

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
