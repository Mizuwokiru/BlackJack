import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GameComponent } from './game/game.component';
import { LoginComponent } from './login/login.component';
import { MenuComponent } from './menu/menu.component';
import { HistoryComponent } from './history/history.component';
import { GameHistoryComponent } from './game-history/game-history.component';
import { RoundHistoryComponent } from './round-history/round-history.component';
import { LoginGuard } from './_guards/login.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/Menu',
    pathMatch: 'full'
  },
  {
    path: 'Login',
    component: LoginComponent
  },
  {
    path: 'Menu',
    component: MenuComponent,
    canActivate: [LoginGuard]
  },
  {
    path: 'Game',
    component: GameComponent,
    canActivate: [LoginGuard]
  },
  {
    path: 'History',
    component: HistoryComponent,
    canActivate: [LoginGuard]
  },
  {
    path: 'History/:gameId',
    component: GameHistoryComponent,
    canActivate: [LoginGuard]
  },
  {
    path: 'History/:gameId/:roundId',
    component: RoundHistoryComponent,
    canActivate: [LoginGuard]
  },
  {
    path: '**',
    redirectTo: ''
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
