import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly url: string = 'api/Login';

  constructor(private http: HttpClient) { }

  public get userName(): string {
    return localStorage.getItem('user_name');
  }

  public get isLoggedIn(): boolean {
    return localStorage.getItem('access_token') !== null;
  }

  getUserNames(): Observable<Array<string>> {
    return this.http.get<{ userNames: Array<string> }>(this.url)
      .pipe(map(userNames => {
        return userNames.userNames;
      }));
  }

  login(user: User) {
    return this.http.post(this.url, user)
      .pipe(map((respondUser: User) => {
        if (respondUser && respondUser.token) {
          localStorage.setItem('user_name', respondUser.name);
          localStorage.setItem('access_token', respondUser.token);
        }
      }));
  }

  logout(): void {
    localStorage.removeItem('user_name');
    localStorage.removeItem('access_token');
  }
}
