import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GameService } from '../_services/game.service';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss']
})
export class GameComponent implements OnInit {

  constructor(private router: Router, private menuService: GameService) { }

  ngOnInit() {
  }

  
}
