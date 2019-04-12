import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { LoginService } from '../_services/login.service';
import { ActivatedRoute, Router } from '@angular/router';

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
    this.loginService.getUserNames()
        .subscribe(response => this.userNames = response);

    if (this.loginService.currentUserValue) {
      this.router.navigate(['/']);
    }
    this.returnUrl = this.route.snapshot.queryParamMap['returnUrl'] || '/';
  }

  login() {
    this.loginService.signIn(this.user)
        .subscribe(() => {
          this.router.navigate([this.returnUrl]);
        },
        () => {
          console.error('Error');
        });
  }
}