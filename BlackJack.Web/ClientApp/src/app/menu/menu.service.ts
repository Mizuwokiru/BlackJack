import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Menu } from './menu';

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  private readonly url: string = 'api/Game';

  constructor(private http: HttpClient) { }

  getMenu(): Observable<Menu> {
    return this.http.get<Menu>(`${this.url}/Menu`);
  }

  newGame(botCount: number): Observable<object> {
    return this.http.post(this.url, { botCount });
  }
}
