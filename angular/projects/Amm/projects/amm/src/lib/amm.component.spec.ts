import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { AmmComponent } from './components/amm.component';

describe('AmmComponent', () => {
  let component: AmmComponent;
  let fixture: ComponentFixture<AmmComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ AmmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AmmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
