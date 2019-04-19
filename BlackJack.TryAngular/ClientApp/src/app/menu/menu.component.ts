import { Component, OnInit } from '@angular/core';
import { MenuService } from '../_services/menu.service';
import { Router } from '@angular/router';
import { GameMenu } from '../_models/game-menu.model';
import { range } from 'rxjs';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
  providers: [MenuService]
})
export class MenuComponent implements OnInit {
  menu: GameMenu;
  botIndices: number[] = [];
  botCount: number;

  constructor(
    private menuService: MenuService,
    private router: Router
  ) { }

  ngOnInit() {
    this.menuService.getMenu()
      .subscribe(response => {
        range(0, response.maxBotCount + 1)
          .subscribe(value => this.botIndices.push(value));
        this.menu = response;
      });
    this.botCount = 0;
  }

  newGame() {
    this.menuService.newGame(this.botCount)
      .subscribe(
        () => this.router.navigate(['/Game']),
        () => { }
      );
  }
}
