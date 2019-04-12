import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class MenuService {
    private url: string = 'api/Menu';

    constructor(private http: HttpClient) { }

    hasUnfinishedGames(): Observable<boolean> {
        return this.http.get<boolean>(this.url);
    }
}