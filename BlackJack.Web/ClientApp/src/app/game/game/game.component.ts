import { Component, OnInit } from '@angular/core';
import { RoundInfo } from '../../shared/models/round-info';
import { GameService } from './game.service';
import { Router } from '@angular/router';
import { RoundState } from '../../shared/enums/round-state.enum';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss']
})
export class GameComponent implements OnInit {
  private roundInfo: RoundInfo;

  isCanToStep: boolean | null = null;

  constructor(
    private gameService: GameService,
    private router: Router
  ) { }

  ngOnInit() {
    this.roundInfo = null;
    this.gameService.getRoundInfo()
      .subscribe(
        response => {
          this.roundInfo = response;
          this.isCanToStep = response.players[0].state === RoundState.None;
        }
      );
  }

  step() {
    this.gameService.step()
      .subscribe(() => this.ngOnInit());
  }

  skip() {
    this.gameService.skip()
      .subscribe(() => this.ngOnInit());
  }

  nextRound() {
    this.gameService.nextRound()
      .subscribe(() => this.ngOnInit());
  }

  endGame() {
    this.gameService.endGame()
      .subscribe(() => this.router.navigate(['/']));
  }
}
