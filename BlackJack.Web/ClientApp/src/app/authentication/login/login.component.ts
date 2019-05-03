import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { UserViewModel } from '../../shared/models/user.view-model';
import { UserService } from '../../shared/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  private userNames: Array<string>;
  private user: UserViewModel = {
    name: '',
    token: ''
  };

  private errors: Array<string> | null = null;

  public constructor(
    private userService: UserService,
    private router: Router
  ) { }

  public ngOnInit(): void {
    if (this.userService.isLoggedIn) {
      this.router.navigate(['/']);
    }
    this.userService.getUserNames()
      .subscribe(response => {
          this.userNames = response;
          if (this.userNames.length > 0) {
            this.user.name = this.userNames[0];
          }
        });
  }

  public login(): void {
    this.userService.login(this.user)
      .subscribe(
        response => this.router.navigate(['/']),
        error => {
          if (typeof(error) !== 'string') {
            this.errors = error as Array<string>;
          }
        }
      );
  }

  public clearErrors(): void {
    this.errors = null;
  }

  public changeUserName(): void {
    // @ts-ignore
    $('#user-name-input').dropdown('hide');
  }

  public chooseUserNameFromDropdown(userName: string): void {
    this.user.name = userName;
  }
}
