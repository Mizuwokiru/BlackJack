import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { MenuComponent } from './menu/menu.component';
import { GameComponent } from './game/game.component';
import { HistoryComponent } from './history/history.component';
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
    canActivate: [LoginGuard],
    canActivateChild: [LoginGuard]
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
