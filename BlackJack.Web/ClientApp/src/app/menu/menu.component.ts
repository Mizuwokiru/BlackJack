import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { range } from 'rxjs';
import { MenuViewModel } from './menu.view-model';
import { HttpClient } from '@angular/common/http';
import { NewGameViewModel } from './new-game.view-model';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  private menu: MenuViewModel;
  private isContinueButtonShown: boolean;

  private botIndices: Array<number> = [];
  private newGameViewModel: NewGameViewModel = {
    botCount: 0
  };

  private readonly url: string = 'api/Game';

  constructor(
    private http: HttpClient,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.http.get<MenuViewModel>(`${this.url}/Menu`)
      .subscribe(
        response => {
          range(0, response.maxBotCount + 1)
            .subscribe(value => this.botIndices.push(value));
          this.menu = response;
          this.isContinueButtonShown = response.hasUnfinishedGame;
        }
      );
  }

  newGame() {
    return this.http.post(this.url, this.newGameViewModel)
      .subscribe(
        () => this.router.navigate(['/Game'])
      );
  }
}
