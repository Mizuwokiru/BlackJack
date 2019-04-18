import { Component } from '@angular/core';
import { LoginService } from './_services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(
    private loginService: LoginService,
    private router: Router
  ) { }

  signOut() {
    this.loginService.signOut();
    this.router.navigate(['/Login']);
  }
}
