import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Round } from '../_models/round';

@Injectable({ providedIn: 'root' })
export class GameService {
    private url: string = 'api/Game';

    constructor(private http: HttpClient) { }

    getRoundsInfo(): Observable<Round[]> {
        return this.http.get<Round[]>(this.url);
    }

    step() {
        return this.http.post(`${this.url}/Step`, {});
    }

    skip() {
        return this.http.post(`${this.url}/Skip`, {});
    }

    nextRound() {
        return this.http.post(`${this.url}/NextRound`, {});
    }

    endGame() {
        return this.http.post(`${this.url}/EndGame`, {});
    }
}