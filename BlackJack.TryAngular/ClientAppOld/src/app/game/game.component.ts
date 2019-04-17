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
  roundPlayers: Round[];
  canToPlay: boolean;
  dealer: Round;
  isLoaded: boolean;
  
  constructor(private router: Router,
    private gameService: GameService) {
      router.routeReuseStrategy.shouldReuseRoute = () => false;
    }

    ngOnInit() {
      this.gameService.getRoundsInfo()
        .subscribe(response => {
          let roundPlayers: Round[] = [];
          response.forEach(player => {
            if (player.playerType == PlayerType.Dealer) {
              this.dealer = player;
              return;
            }
            if (player.playerType == PlayerType.User) {
              this.canToPlay = player.state == RoundState.None;
            }
            roundPlayers.push(player);
          });
  
          this.roundPlayers = roundPlayers;
          this.isLoaded = true;
        });
    }
  
    private refresh() {
      this.router.navigate(['/Game']);
      this.ngOnInit();
    }

    step() {
      this.gameService.step()
        .subscribe(() => this.refresh());
    }
  
    skip() {
      this.gameService.skip()
        .subscribe(() => this.refresh());
    }
  
    nextRound() {
      this.gameService.nextRound()
        .subscribe(() => this.refresh());
    }
  
    endGame() {
      this.gameService.endGame()
        .subscribe(() => this.router.navigate(['/']));
    }
}
