import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserViewModel } from '../models/user.view-model';
import { UserNamesViewModel } from '../models/user-names.view-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly url: string = 'api/Authentication';

  public constructor(private http: HttpClient) { }

  public get userName(): string {
    return localStorage.getItem('user_name');
  }

  public get isLoggedIn(): boolean {
    return localStorage.getItem('access_token') !== null;
  }

  public getUserNames(): Observable<Array<string>> {
    return this.http.get<UserNamesViewModel>(`${this.url}/Login`)
      .pipe(map(userNames => {
        return userNames.userNames;
      }));
  }

  public login(user: UserViewModel) {
    return this.http.post(`${this.url}/Login`, user)
      .pipe(map((respondUser: UserViewModel) => {
        if (respondUser && respondUser.token) {
          localStorage.setItem('user_name', respondUser.name);
          localStorage.setItem('access_token', respondUser.token);
        }
      }));
  }

  public logout(): void {
    this.http.post(`${this.url}/Logout`, {})
      .subscribe();
    localStorage.removeItem('user_name');
    localStorage.removeItem('access_token');
  }
}
