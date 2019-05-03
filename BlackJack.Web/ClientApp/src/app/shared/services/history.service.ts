import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { GameViewModel } from '../models/game.view-model';
import { GamesHistoryViewModel } from '../models/games-history.view-model';
import { RoundsHistoryViewModel } from '../models/rounds-history.view-model';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {
  private readonly url: string = 'api/History';

  public constructor(private http: HttpClient) { }

  public getGamesHistory(): Observable<GamesHistoryViewModel> {
    return this.http.get<GamesHistoryViewModel>(this.url);
  }

  public getRoundsHistory(gameSkipCount: number): Observable<RoundsHistoryViewModel> {
    return this.http.get<RoundsHistoryViewModel>(`${this.url}/${gameSkipCount}`);
  }

  public getRoundInfo(gameSkipCount: number, roundSkipCount: number): Observable<GameViewModel> {
    return this.http.get<GameViewModel>(`${this.url}/${gameSkipCount}/${roundSkipCount}`);
  }
}
