import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class GameService {
    private url: string = 'api/Game';

    constructor(private http: HttpClient) { }
}