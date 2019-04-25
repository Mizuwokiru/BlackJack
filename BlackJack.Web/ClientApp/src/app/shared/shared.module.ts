import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoundInfoComponent } from './components/round-info/round-info.component';
import { RoundPlayerInfoComponent } from './components/round-info/round-player-info/round-player-info.component';
import { CardComponent } from './components/round-info/round-player-info/card/card.component';

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
