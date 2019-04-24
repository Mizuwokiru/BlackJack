import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { MenuService } from './menu.service';
import { range } from 'rxjs';
import { Menu } from './menu';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  private menu: Menu;
  private isContinueButtonShown: boolean;

  private botIndices: Array<number> = [];
  private botCount = 0;

  constructor(
    private menuService: MenuService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.menuService.getMenu()
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
    this.menuService.newGame(this.botCount)
      .subscribe(
        () => this.router.navigate(['/Game'])
      );
  }
}
