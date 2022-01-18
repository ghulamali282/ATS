import { APP_INITIALIZER } from '@angular/core';
import {
  ManageProfileTabsService,
} from '@volo/abp.ng.account/public/config';
import { UserProfileSettingComponent } from '../profile-tabs/user-profile-setting/user-profile-setting.component';

export const MANAGE_PROFILE_TAB_PROVIDER = {
  provide: APP_INITIALIZER,
  useFactory: configureManageProfileTabs,
  deps: [ManageProfileTabsService],
  multi: true,
};

export function configureManageProfileTabs(tabs: ManageProfileTabsService) {
  return () => {
    tabs.add([
      {
        name: '::Settings',
        order: 5,
        component: UserProfileSettingComponent,
      },
    ]);
  };
}