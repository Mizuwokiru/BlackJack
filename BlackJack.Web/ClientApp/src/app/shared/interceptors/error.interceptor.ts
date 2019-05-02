import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { UserService } from '../services/user.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  public constructor(private userService: UserService, private router: Router) { }

  public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(error => {
      if (error.status === 401) {
        this.userService.logout();
        this.router.navigate(['/Authentication']);
      }

      if (error.error && error.error.Name) {
        return throwError(error.error.Name as Array<string>);
      }
      if (error.error && error.error.StatusCode && error.error.StatusText) {
        return throwError(`${error.error.StatusCode} ${error.error.StatusText}`);
      }
      return throwError(`${error.status} ${error.statusText}`);
    }));
  }
}
