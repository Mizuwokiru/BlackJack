import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GameMenu } from '../_models/game-menu.model';

@Injectable()
export class MenuService {
  private readonly url: string = 'api/Menu';

  constructor(private http: HttpClient) { }

  getMenu(): Observable<GameMenu> {
    return this.http.get<GameMenu>(this.url);
  }

  newGame(botCount: number) {
    return this.http.post(`${this.url}/NewGame`, { botCount: botCount });
  }
}
