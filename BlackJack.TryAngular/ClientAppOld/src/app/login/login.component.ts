import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { User } from '../_models/user';
import { LoginService } from '../_services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  user: User = new User();
  userNames: string[];
  returnUrl: string;

  constructor(
      private route: ActivatedRoute,
      private router: Router,
      private loginService: LoginService) { }

  ngOnInit() {
    if (this.loginService.currentUserValue) {
      this.router.navigate(['/']);
    }
    this.returnUrl = this.route.snapshot.queryParamMap['returnUrl'] || '/';
    this.loginService.getUserNames()
        .subscribe(response => { 
          this.userNames = response;
          if (this.userNames.length > 0) {
            this.user.name = this.userNames[0];
          }
        });
  }

  login() {
    this.loginService.signIn(this.user)
        .subscribe(() => {
          this.router.navigate([this.returnUrl]);
        },
        () => {
          console.error('LoginComponent.login() error.');
        });
  }

  onChangeDropdownUser(name: string) {
    this.user.name = name;
  }
}
