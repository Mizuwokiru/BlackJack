import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { MenuComponent } from './menu/menu.component';
import { GameComponent } from './game/game.component';
import { HistoryComponent } from './history/history.component';
import { LoginGuard } from './_guards/login.guard';
import { GameHistoryComponent } from './history/game-history/game-history.component';
import { RoundHistoryComponent } from './history/game-history/round-history/round-history.component';

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
