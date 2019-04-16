import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { PlayerType } from '../_enums/player-type';
import { RoundState } from '../_enums/round-state';
import { Round } from '../_models/round';
import { GameService } from '../_services/game.service';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss']
})
export class GameComponent implements OnInit {
  roundPlayers: Round[] = [];
  canToPlay: boolean;
  dealer: Round;
  isLoaded: boolean;
  
  constructor(private router: Router,
    private gameService: GameService) { }

    ngOnInit() {
      this.gameService.getRoundsInfo()
        .subscribe(response => {
          response.forEach(player => {
            if (player.playerType == PlayerType.Dealer) {
              this.dealer = player;
              return;
            }
            if (player.playerType == PlayerType.User) {
              this.canToPlay = player.state == RoundState.None;
            }
            this.roundPlayers.push(player);
          });
  
          this.isLoaded = true;
        });
    }
  
    step() {
      this.gameService.step()
        .subscribe(() => this.router.navigate(['/Game']));
    }
  
    skip() {
      this.gameService.skip()
        .subscribe(() => this.router.navigate(['/Game']));
    }
  
    nextRound() {
      this.gameService.nextRound()
        .subscribe(() => this.router.navigate(['/Game']));
    }
  
    endGame() {
      this.gameService.endGame()
        .subscribe(() => this.router.navigate(['/']));
    }
}
