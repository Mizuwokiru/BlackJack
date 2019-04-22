import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../_models/user.model';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private readonly url: string = 'api/Login';
  private currentUserSubject: BehaviorSubject<User>;

  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(sessionStorage.getItem('currentUser')));
  }

  public get currentUser(): User {
    return this.currentUserSubject.value;
  }

  getUserNames(): Observable<Array<string>> {
    return this.http.get<Array<string>>(this.url);
  }

  signIn(user: User) {
    return this.http.post(this.url, user)
      .pipe(map((user: User) => {
        if (user && user.token) {
          sessionStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUserSubject.next(user);
        }
        return user;
      }));
  }

  signOut(): void {
    sessionStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}
