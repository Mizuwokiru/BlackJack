import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoundInfoComponent } from './components/round-info/round-info.component';
import { RoundPlayerInfoComponent } from './components/round-player-info/round-player-info.component';
import { CardComponent } from './components/card/card.component';

@NgModule({
  declarations: [RoundInfoComponent, RoundPlayerInfoComponent, CardComponent],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
