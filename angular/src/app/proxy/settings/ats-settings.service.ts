import type { UserProfileSettingDto } from './dto/models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AtsSettingsService {
  apiName = 'Default';

  getUserProfileSettingByUserId = (userId: string) =>
    this.restService.request<any, UserProfileSettingDto>({
      method: 'GET',
      url: `/api/app/ats-settings/user-profile-setting/${userId}`,
    },
    { apiName: this.apiName });

  updateUserProfileSettingsByUserIdAndSettings = (userId: string, settings: UserProfileSettingDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/ats-settings/user-profile-settings/${userId}`,
      body: settings,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
