import type { GetMasterDatasInput, MasterDataCreateDto, MasterDataDto, MasterDataUpdateDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class MasterDataService {
  apiName = 'Ccm';

  create = (input: MasterDataCreateDto) =>
    this.restService.request<any, MasterDataDto>({
      method: 'POST',
      url: '/api/ccm/master-datas',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/ccm/master-datas/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, MasterDataDto>({
      method: 'GET',
      url: `/api/ccm/master-datas/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetMasterDatasInput) =>
    this.restService.request<any, PagedResultDto<MasterDataDto>>({
      method: 'GET',
      url: '/api/ccm/master-datas',
      params: { filterText: input.filterText, parentId: input.parentId, name: input.name, value: input.value, inlineValue: input.inlineValue, visibleToTenant: input.visibleToTenant, isSection: input.isSection, isRadio: input.isRadio, isExportable: input.isExportable, icon: input.icon, cultureName: input.cultureName, sortOrderMin: input.sortOrderMin, sortOrderMax: input.sortOrderMax, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: MasterDataUpdateDto) =>
    this.restService.request<any, MasterDataDto>({
      method: 'PUT',
      url: `/api/ccm/master-datas/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
