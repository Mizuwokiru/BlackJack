import { Component, Input } from '@angular/core';
import { Player } from '../../models/player';

@Component({
  selector: 'app-round-player-info',
  templateUrl: './round-player-info.component.html',
  styleUrls: ['./round-player-info.component.scss']
})
export class RoundPlayerInfoComponent {
  @Input() player: Player;

  readonly colorClasses: string[][] = [
    [ '', 'border-success', 'border-danger', 'border-primary' ],
    [ '', 'text-success', 'text-danger', 'text-primary' ]
  ];
}
