import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HistoryGame } from '../_models/history-game.model';
import { HistoryRounds } from '../_models/history-rounds.model';
import { Round } from '../_models/round.model';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {
  private readonly url: string = 'api/History';

  constructor(private http: HttpClient) { }

  getGames(): Observable<HistoryGame[]> {
    return this.http.get<HistoryGame[]>(this.url);
  }

  getRounds(gameId): Observable<HistoryRounds> {
    return this.http.get<HistoryRounds>(`${this.url}/${gameId}`);
  }

  getRoundInfo(gameId, roundId): Observable<Round[]> {
    return this.http.get<Round[]>(`${this.url}/${gameId}/${roundId}`);
  }
}
