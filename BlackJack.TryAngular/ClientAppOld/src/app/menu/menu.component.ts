import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { range } from 'rxjs';

import { Menu } from '../_models/menu';
import { MenuService } from '../_services/menu.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  isLoaded: boolean = false;
  menu: Menu;
  botIndices: number[] = [];
  botCount: number;

  constructor(private router: Router, private menuService: MenuService) { }

  ngOnInit() {
    this.menuService.getMenu()
      .subscribe(response => {
          this.menu = response;
          range(1, this.menu.maxBotCount)
            .subscribe(value => this.botIndices.push(value));
          this.isLoaded = true;
      });
  }

  newGame() {
    this.menuService.newGame(this.botCount)
      .subscribe(
        () => this.router.navigate(['/Game']),
        () => console.error("MenuComponent.newGame() error.")
      );
  }
}
