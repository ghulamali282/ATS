import type { AppDefaultCreateDto, AppDefaultDto, AppDefaultUpdateDto, GetAppDefaultsInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AppDefaultService {
  apiName = 'Amm';

  create = (input: AppDefaultCreateDto) =>
    this.restService.request<any, AppDefaultDto>({
      method: 'POST',
      url: '/api/amm/app-defaults',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/amm/app-defaults/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, AppDefaultDto>({
      method: 'GET',
      url: `/api/amm/app-defaults/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetAppDefaultsInput) =>
    this.restService.request<any, PagedResultDto<AppDefaultDto>>({
      method: 'GET',
      url: '/api/amm/app-defaults',
      params: { filterText: input.filterText, settingsName: input.settingsName, settingsValue: input.settingsValue, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: AppDefaultUpdateDto) =>
    this.restService.request<any, AppDefaultDto>({
      method: 'PUT',
      url: `/api/amm/app-defaults/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
