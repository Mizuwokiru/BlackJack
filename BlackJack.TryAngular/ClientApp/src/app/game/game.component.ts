import { Component, OnInit } from '@angular/core';
import { GameService } from '../_services/game.service';
import { RoundInfo } from '../_models/round-info.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss'],
  providers: [GameService]
})
export class GameComponent implements OnInit {
  roundInfo: RoundInfo;

  constructor(
    private gameService: GameService,
    private router: Router
  ) { }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.roundInfo = null;
    this.gameService.getRoundsInfo()
      .subscribe(
        response => this.roundInfo = response,
        () => { }
      );
  }

  step() {
    this.gameService.step()
      .subscribe(
        () => this.refresh(),
        () => { }
      );
  }

  skip() {
    this.gameService.skip()
      .subscribe(
        () => this.refresh(),
        () => { }
      );
  }

  nextRound() {
    this.gameService.nextRound()
      .subscribe(
        () => this.refresh(),
        () => { }
      );
  }

  endGame() {
    this.gameService.endGame()
      .subscribe(
        () => this.router.navigate(['/']),
        () => { }
      );
  }
}
