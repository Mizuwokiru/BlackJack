import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RoundPlayerInfoComponent } from './round-player-info.component';

describe('RoundPlayerInfoComponent', () => {
  let component: RoundPlayerInfoComponent;
  let fixture: ComponentFixture<RoundPlayerInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RoundPlayerInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RoundPlayerInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
