import { Component, OnInit } from '@angular/core';
import { GameService } from '../_services/game.service';
import { RoundInfo } from '../_models/round-info.model';
import { Router } from '@angular/router';
import { RoundState } from '../_enums/round-state.enum';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss'],
  providers: [GameService]
})
export class GameComponent implements OnInit {
  roundInfo: RoundInfo;

  isCanToStep: boolean | null = null;

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
        response => {
          this.roundInfo = response;
          this.isCanToStep = response.user.state == RoundState.None;
        },
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
