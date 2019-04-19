import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { MenuComponent } from './menu/menu.component';
import { GameComponent } from './game/game.component';
import { HistoryComponent } from './history/history.component';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { RoundInfoComponent } from './round-info/round-info.component';
import { RoundPlayerInfoComponent } from './round-info/round-player-info/round-player-info.component';
import { CardComponent } from './round-info/round-player-info/card/card.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { GameHistoryComponent } from './history/game-history/game-history.component';
import { RoundHistoryComponent } from './history/game-history/round-history/round-history.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    MenuComponent,
    GameComponent,
    HistoryComponent,
    RoundInfoComponent,
    RoundPlayerInfoComponent,
    CardComponent,
    GameHistoryComponent,
    RoundHistoryComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
