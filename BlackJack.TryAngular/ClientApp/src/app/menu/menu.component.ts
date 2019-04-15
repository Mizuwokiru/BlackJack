import { Component, OnInit } from '@angular/core';
import { MenuService } from '../_services/menu.service';
import { range } from 'rxjs';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  isLoaded: boolean = false;
  isContinueButtonShow: boolean = false;
  somes: string[];  
  botIndices: number[] = [];

  constructor(private menuService: MenuService) { }

  ngOnInit() {
    range(0, 8)
        .subscribe(value => this.botIndices.push(value));

    this.menuService.hasUnfinishedGames()
        .subscribe(response => {
          this.isContinueButtonShow = response;
          this.isLoaded = true;
        });
  }

}
