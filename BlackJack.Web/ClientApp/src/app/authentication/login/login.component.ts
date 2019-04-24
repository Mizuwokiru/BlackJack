import { Component, OnInit } from '@angular/core';
import { User } from '../../shared/models/user';
import { UserService } from '../../shared/services/user.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  private userNames: Array<string>;
  private user: User = new User();

  private errors: Array<string> | null = null;

  constructor(
    private userService: UserService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.userService.getUserNames()
      .subscribe(response => {
          this.userNames = response;
          if (this.userNames.length > 0) {
            this.user.name = this.userNames[0];
          }
        },
        error => console.error(error));
  }

  login(): void {
    this.userService.login(this.user)
      .subscribe(
        response => this.router.navigate(['/']),
        error => {
          this.errors = error as Array<string>;
        }
      );
  }

  clearErrors(): void {
    this.errors = null;
  }

  changeUserName(): void {
    // @ts-ignore
    $('#user-name-input').dropdown('hide');
  }

  chooseUserNameFromDropdown(userName: string): void {
    this.user.name = userName;
  }
}
