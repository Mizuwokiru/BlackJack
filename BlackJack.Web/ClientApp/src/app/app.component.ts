import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from './shared/services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public constructor(
    private userService: UserService,
    private router: Router
  ) { }

  public signOut() {
    this.userService.logout();
    this.router.navigate(['/Authentication/Login']);
  }
}
