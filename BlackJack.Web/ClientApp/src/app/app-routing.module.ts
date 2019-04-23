import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MenuComponent } from './menu/menu.component';
import { AuthenticationGuard } from './shared/guards/authentication.guard';
import { NoAuthenticationGuard } from './shared/guards/no-authentication.guard';

const routes: Routes = [
  {
    path: '',
    component: MenuComponent,
    canActivate: [AuthenticationGuard]
  },
  {
    path: 'Authentication',
    loadChildren: './authentication/authentication.module#AuthenticationModule',
    canActivate: [NoAuthenticationGuard]
  },
  {
    path: 'Game',
    loadChildren: './game/game.module#GameModule',
    canActivate: [AuthenticationGuard]
  },
  {
    path: 'History',
    loadChildren: './history/history.module#HistoryModule',
    canActivate: [AuthenticationGuard]
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
