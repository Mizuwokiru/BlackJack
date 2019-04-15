import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Menu } from '../_models/menu';

@Injectable({ providedIn: 'root' })
export class MenuService {
    private url: string = 'api/Menu';

    constructor(private http: HttpClient) { }

    getMenu(): Observable<Menu> {
        return this.http.get<Menu>(this.url);
    }

    newGame(menu: Menu): Observable<any> {
        return this.http.post(`${this.url}/NewGame`, menu);
    }
}