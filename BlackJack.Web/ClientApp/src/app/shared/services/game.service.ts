import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GameViewModel } from '../models/game.view-model';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private readonly url: string = 'api/Game';

  public constructor(private http: HttpClient) { }

  public getRoundInfo() {
    return this.http.get<GameViewModel>(this.url);
  }

  public step() {
    return this.http.post(`${this.url}/Step`, {});
  }

  public skip() {
    return this.http.post(`${this.url}/Skip`, {});
  }

  public nextRound() {
    return this.http.post(`${this.url}/NextRound`, {});
  }

  public endGame() {
    return this.http.post(`${this.url}/EndGame`, {});
  }
}
