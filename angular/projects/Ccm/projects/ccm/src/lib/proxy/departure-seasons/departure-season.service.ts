import type { DepartureSeasonCreateDto, DepartureSeasonDto, DepartureSeasonUpdateDto, DepartureSeasonWithNavigationPropertiesDto, GetDepartureSeasonsInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class DepartureSeasonService {
  apiName = 'Ccm';

  create = (input: DepartureSeasonCreateDto) =>
    this.restService.request<any, DepartureSeasonDto>({
      method: 'POST',
      url: '/api/ccm/departure-seasons',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/ccm/departure-seasons/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, DepartureSeasonDto>({
      method: 'GET',
      url: `/api/ccm/departure-seasons/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetDepartureSeasonsInput) =>
    this.restService.request<any, PagedResultDto<DepartureSeasonWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/ccm/departure-seasons',
      params: { filterText: input.filterText, seasonMin: input.seasonMin, seasonMax: input.seasonMax, seasonName: input.seasonName, partner: input.partner, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getPartnerLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/departure-seasons/partner-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: string) =>
    this.restService.request<any, DepartureSeasonWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/ccm/departure-seasons/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: string, input: DepartureSeasonUpdateDto) =>
    this.restService.request<any, DepartureSeasonDto>({
      method: 'PUT',
      url: `/api/ccm/departure-seasons/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
