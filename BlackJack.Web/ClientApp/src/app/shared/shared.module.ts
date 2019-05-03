import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { RoundInfoComponent } from './components/round-info/round-info.component';
import { CardComponent } from './components/round-info/round-player-info/card/card.component';
import { RoundPlayerInfoComponent } from './components/round-info/round-player-info/round-player-info.component';

@NgModule({
  declarations: [RoundInfoComponent, RoundPlayerInfoComponent, CardComponent],
  exports: [
    RoundInfoComponent
  ],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
