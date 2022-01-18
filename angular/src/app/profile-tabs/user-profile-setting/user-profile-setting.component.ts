import { ConfigStateService } from '@abp/ng.core';
import { ToasterService } from '@abp/ng.theme.shared';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { AtsSettingsService } from '@proxy/settings';
import { UserProfileSettingDto } from '@proxy/settings/dto';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-user-profile-setting',
  templateUrl: './user-profile-setting.component.html',
  styleUrls: ['./user-profile-setting.component.scss'],
})
export class UserProfileSettingComponent implements OnInit, OnDestroy {
  form: FormGroup;
  currentUser: any;
  onDestroy$ = new Subject();
  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly configState: ConfigStateService,
    private readonly toasterService: ToasterService,
    private readonly atsSettingsService: AtsSettingsService
  ) {}

  ngOnInit(): void {
    this.currentUser = this.configState.getOne('currentUser');
    this.atsSettingsService
      .getUserProfileSettingByUserId(this.currentUser.id)
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(settings => {
        this.buildForm(settings);
      });
  }

  buildForm(profileSettings: UserProfileSettingDto) {
    this.form = this.formBuilder.group({
      workingYear: new FormControl(profileSettings.workingYear),
    });
  }

  save() {
    if (!this.form.valid) return;
    const currentUser = this.configState.getOne('currentUser');
    this.atsSettingsService
      .updateUserProfileSettingsByUserIdAndSettings(currentUser.id, this.form.value)
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(() => {
        this.toasterService.success('Profile settings updated');
      });
  }

  ngOnDestroy() {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }
}
