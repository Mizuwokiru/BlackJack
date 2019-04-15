import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Round } from '../_models/round';

@Injectable({ providedIn: 'root' })
export class GameService {
    private url: string = 'api/Game';

    constructor(private http: HttpClient) { }

    getRoundsInfo(): Round[] {
        return null;
    }
}