import { Component, OnInit } from '@angular/core';
import { MenuService } from '../_services/menu.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  isLoaded: boolean = false;
  isContinueButtonShow: boolean = false;
  somes: string[];  

  constructor(private menuService: MenuService) { }

  ngOnInit() {
    this.menuService.hasUnfinishedGames()
        .subscribe(response => {
          this.isContinueButtonShow = response;
          this.isLoaded = true;
        });
  }

}
