import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { GameService } from '../_services/game.service';
import { Card } from '../_models/card';
import { Round } from '../_models/round';
import { CardHelper } from '../_helpers/card.helper';
import { RoundState } from '../_enums/round.state';
import { PlayerType } from '../_enums/player.type';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss']
})
export class GameComponent implements OnInit {
  roundPlayers: Round[];
  canToPlay: boolean;
  dealer: Round;

  constructor(private router: Router,
    private route: ActivatedRoute,
    private gameService: GameService) { }

  ngOnInit() {
    this.gameService.getRoundsInfo()
      .subscribe(response => {
        response.forEach(player => {
          player.stringifiedCards = CardHelper.getCardsHtml(player.cards);
          if (player.playerType == PlayerType.Dealer) {
            this.dealer = player;
            return;
          }
          if (player.playerType == PlayerType.User) {
            this.canToPlay = player.state == RoundState.None;
          }
          this.roundPlayers.push(player);
        });
      });
  }

  step() {
    this.gameService.step()
      .subscribe(() => this.router.navigate([this.route]));
  }

  skip() {

  }

  nextRound() {

  }

  endGame() {

  }

  quit() {
    
  }
}
