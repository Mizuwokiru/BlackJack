import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GameViewModel } from '../../shared/models/game.view-model';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private readonly url: string = 'api/Game';

  constructor(private http: HttpClient) { }

  getRoundInfo() {
    return this.http.get<GameViewModel>(this.url);
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
