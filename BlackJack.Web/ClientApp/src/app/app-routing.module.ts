import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MenuComponent } from './menu/menu.component';

const routes: Routes = [
  {
    path: '',
    component: MenuComponent
  },
  {
    path: 'Authentication',
    loadChildren: './authentication/authentication.module#AuthenticationModule'
  },
  {
    path: 'Game',
    loadChildren: './game/game.module#GameModule'
  },
  {
    path: 'History',
    loadChildren: './history/history.module#HistoryModule'
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
