import { Component, Input } from '@angular/core';
import { PlayerGameViewModel } from '../../../models/player-game.view-model';

@Component({
  selector: 'app-round-player-info',
  templateUrl: './round-player-info.component.html',
  styleUrls: ['./round-player-info.component.scss']
})
export class RoundPlayerInfoComponent {
  @Input() private player: PlayerGameViewModel;

  private readonly colorClasses: string[][] = [
    [ '', 'border-success', 'border-danger', 'border-primary' ],
    [ '', 'text-success', 'text-danger', 'text-primary' ]
  ];
}
