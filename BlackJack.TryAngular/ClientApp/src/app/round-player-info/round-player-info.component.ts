import { Component, Input, OnInit } from '@angular/core';

import { Round } from '../_models/round';

@Component({
  selector: 'app-round-player-info',
  templateUrl: './round-player-info.component.html'
})
export class RoundPlayerInfoComponent implements OnInit {
  @Input() roundPlayer: Round;
  
  readonly colorClasses: string[][] = [
    [ "", "border-success", "border-danger", "border-primary" ],
    [ "", "text-success", "text-danger", "text-primary" ]
  ];
 
  constructor() { }

  ngOnInit() {
    
  }

}
