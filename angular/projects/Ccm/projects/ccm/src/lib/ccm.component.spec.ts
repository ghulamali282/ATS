import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { CcmComponent } from './components/ccm.component';

describe('CcmComponent', () => {
  let component: CcmComponent;
  let fixture: ComponentFixture<CcmComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ CcmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CcmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
