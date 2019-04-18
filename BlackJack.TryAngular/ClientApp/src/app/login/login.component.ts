import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user.model';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from '../_services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  userNames: string[];
  user: User = new User();
  returnUrl: string;

  constructor(
    private loginService: LoginService,
    private router: Router,
    private route: ActivatedRoute) { }

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

  signIn(): void {
    this.loginService.signIn(this.user)
      .subscribe(
        () => this.router.navigate([this.returnUrl]),
        () => { } // TODO: validation
      );
  }

  onChangeUserName(): void {
    // @ts-ignore
    $('#userNameInput').dropdown('hide');
  }

  onChooseUserNameFromDropdown(userName: string): void {
    this.user.name = userName;
  }
}
