import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserProfileSettingComponent } from './user-profile-setting.component';

describe('UserProfileSettingComponent', () => {
  let component: UserProfileSettingComponent;
  let fixture: ComponentFixture<UserProfileSettingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserProfileSettingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserProfileSettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
