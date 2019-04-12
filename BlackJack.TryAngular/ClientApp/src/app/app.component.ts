import { Component } from '@angular/core';
import { User } from './_models/user';
import { Router } from '@angular/router';
import { LoginService } from './_services/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  currentUser: User;

  constructor(
    private router: Router,
    private loginService: LoginService
  ) {
    this.loginService.currentUser
        .subscribe(user => this.currentUser = user);
  }
}
