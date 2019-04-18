import { Component, Input, OnInit } from '@angular/core';
import { RoundInfo } from '../_models/round-info.model';

@Component({
  selector: 'app-round-info',
  templateUrl: './round-info.component.html',
  styleUrls: ['./round-info.component.scss']
})
export class RoundInfoComponent implements OnInit {
  @Input() roundInfo: RoundInfo;

  ngOnInit() { }

}
