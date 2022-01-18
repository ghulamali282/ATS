import type { CruiseRegionCreateDto, CruiseRegionDto, CruiseRegionUpdateDto, CruiseRegionWithNavigationPropertiesDto, GetCruiseRegionsInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CruiseRegionService {
  apiName = 'Amm';

  create = (input: CruiseRegionCreateDto) =>
    this.restService.request<any, CruiseRegionDto>({
      method: 'POST',
      url: '/api/amm/cruise-regions',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/amm/cruise-regions/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, CruiseRegionDto>({
      method: 'GET',
      url: `/api/amm/cruise-regions/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetCruiseRegionsInput) =>
    this.restService.request<any, PagedResultDto<CruiseRegionWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/amm/cruise-regions',
      params: { filterText: input.filterText, freeEntry: input.freeEntry, cruiseRegionName: input.cruiseRegionName, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getMasterDataLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/amm/cruise-regions/master-data-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: string) =>
    this.restService.request<any, CruiseRegionWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/amm/cruise-regions/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: string, input: CruiseRegionUpdateDto) =>
    this.restService.request<any, CruiseRegionDto>({
      method: 'PUT',
      url: `/api/amm/cruise-regions/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
