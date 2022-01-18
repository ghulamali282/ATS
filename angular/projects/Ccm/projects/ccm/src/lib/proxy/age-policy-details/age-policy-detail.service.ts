import type { AgePolicyDetailCreateDto, AgePolicyDetailDto, AgePolicyDetailUpdateDto, AgePolicyDetailWithNavigationPropertiesDto, GetAgePolicyDetailsInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class AgePolicyDetailService {
  apiName = 'Ccm';

  create = (input: AgePolicyDetailCreateDto) =>
    this.restService.request<any, AgePolicyDetailDto>({
      method: 'POST',
      url: '/api/ccm/age-policy-details',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/ccm/age-policy-details/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, AgePolicyDetailDto>({
      method: 'GET',
      url: `/api/ccm/age-policy-details/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetAgePolicyDetailsInput) =>
    this.restService.request<any, PagedResultDto<AgePolicyDetailWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/ccm/age-policy-details',
      params: { filterText: input.filterText, ageFromMin: input.ageFromMin, ageFromMax: input.ageFromMax, agePolicy: input.agePolicy, ageToMin: input.ageToMin, ageToMax: input.ageToMax, service: input.service, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getMasterDataLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/age-policy-details/master-data-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: string) =>
    this.restService.request<any, AgePolicyDetailWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/ccm/age-policy-details/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: string, input: AgePolicyDetailUpdateDto) =>
    this.restService.request<any, AgePolicyDetailDto>({
      method: 'PUT',
      url: `/api/ccm/age-policy-details/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
