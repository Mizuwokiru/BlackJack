import { Injectable } from '@angular/core';
import { GamesHistoryViewModel } from './games-history/games-history.view-model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RoundsHistoryViewModel } from './rounds-history/rounds-history.view-model';
import { GameViewModel } from '../shared/models/game.view-model';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {
  private readonly url: string = 'api/History';

  constructor(private http: HttpClient) { }

  getGamesHistory(): Observable<GamesHistoryViewModel> {
    return this.http.get<GamesHistoryViewModel>(this.url);
  }

  getRoundsHistory(gameSkipCount: number): Observable<RoundsHistoryViewModel> {
    return this.http.get<RoundsHistoryViewModel>(`${this.url}/${gameSkipCount}`);
  }

  getRoundInfo(gameSkipCount: number, roundSkipCount: number): Observable<GameViewModel> {
    return this.http.get<GameViewModel>(`${this.url}/${gameSkipCount}/${roundSkipCount}`);
  }
}
