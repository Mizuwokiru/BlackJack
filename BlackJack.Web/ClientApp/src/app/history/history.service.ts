import { Injectable } from '@angular/core';
import { GamesHistory } from './games-history/games-history';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RoundsHistory } from './rounds-history/rounds-history';
import { RoundInfo } from '../shared/models/round-info';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {
  private readonly url: string = 'api/History';

  constructor(private http: HttpClient) { }

  getGamesHistory(): Observable<GamesHistory> {
    return this.http.get<GamesHistory>(this.url);
  }

  getRoundsHistory(gameSkipCount: number): Observable<RoundsHistory> {
    return this.http.get<RoundsHistory>(`${this.url}/${gameSkipCount}`);
  }

  getRoundInfo(gameSkipCount: number, roundSkipCount: number): Observable<RoundInfo> {
    return this.http.get<RoundInfo>(`${this.url}/${gameSkipCount}/${roundSkipCount}`);
  }
}
