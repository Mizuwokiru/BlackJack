import { Component, OnInit, Input } from '@angular/core';
import { Round } from '../_models/round';

@Component({
  selector: 'app-round-info',
  templateUrl: './round-info.component.html',
  styleUrls: ['./round-info.component.scss']
})
export class RoundInfoComponent implements OnInit {
  @Input() roundPlayers: Round[];
  @Input() dealer: Round;

  constructor() { }

  ngOnInit() {
  }

}
