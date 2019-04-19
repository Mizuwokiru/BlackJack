import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HistoryGame } from '../_models/history-game.model';
import { HistoryRounds } from '../_models/history-rounds.model';
import { Round } from '../_models/round.model';
import { RoundInfo } from '../_models/round-info.model';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {
  private readonly url: string = 'api/History';

  constructor(private http: HttpClient) { }

  getGames(): Observable<Array<HistoryGame>> {
    return this.http.get<Array<HistoryGame>>(this.url);
  }

  getRounds(gameId): Observable<HistoryRounds> {
    return this.http.get<HistoryRounds>(`${this.url}/${gameId}`);
  }

  getRoundInfo(gameId, roundId): Observable<RoundInfo> {
    return this.http.get<RoundInfo>(`${this.url}/${gameId}/${roundId}`);
  }
}
