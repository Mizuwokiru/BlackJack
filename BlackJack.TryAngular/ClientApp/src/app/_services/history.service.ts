import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Game } from '../_models/game';
import { GameInfo } from '../_models/game-info';
import { Round } from '../_models/round';

@Injectable({ providedIn: 'root' })
export class HistoryService {
    private url: string = 'api/History';

    constructor(private http: HttpClient) { }

    getGames(): Observable<Game[]> {
        return this.http.get<Game[]>(this.url);
    }

    getGameInfo(gameId: number): Observable<GameInfo> {
        return this.http.get<GameInfo>(`${this.url}/${gameId}`);
    }

    getRoundInfo(gameId: number, roundId: number): Observable<Round[]> {
        return this.http.get<Round[]>(`${this.url}/${gameId}/${roundId}`);
    }
}