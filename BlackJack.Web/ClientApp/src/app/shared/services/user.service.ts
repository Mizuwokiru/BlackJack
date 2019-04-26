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
  private readonly url: string = 'api/Login';

  constructor(private http: HttpClient) { }

  public get userName(): string {
    return localStorage.getItem('user_name');
  }

  public get isLoggedIn(): boolean {
    return localStorage.getItem('access_token') !== null;
  }

  getUserNames(): Observable<Array<string>> {
    return this.http.get<UserNamesViewModel>(this.url)
      .pipe(map(userNames => {
        return userNames.userNames;
      }));
  }

  login(user: UserViewModel) {
    return this.http.post(this.url, user)
      .pipe(map((respondUser: UserViewModel) => {
        if (respondUser && respondUser.token) {
          localStorage.setItem('user_name', respondUser.name);
          localStorage.setItem('access_token', respondUser.token);
        }
      }));
  }

  logout(): void {
    this.http.delete(this.url)
      .subscribe();
    localStorage.removeItem('user_name');
    localStorage.removeItem('access_token');
  }
}
