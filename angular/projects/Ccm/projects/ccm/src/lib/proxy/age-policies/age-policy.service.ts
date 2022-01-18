import type { AgePolicyCreateDto, AgePolicyDto, AgePolicyUpdateDto, AgePolicyWithNavigationPropertiesDto, GetAgePoliciesInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class AgePolicyService {
  apiName = 'Ccm';

  create = (input: AgePolicyCreateDto) =>
    this.restService.request<any, AgePolicyDto>({
      method: 'POST',
      url: '/api/ccm/age-policies',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/ccm/age-policies/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, AgePolicyDto>({
      method: 'GET',
      url: `/api/ccm/age-policies/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetAgePoliciesInput) =>
    this.restService.request<any, PagedResultDto<AgePolicyWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/ccm/age-policies',
      params: { filterText: input.filterText, demoField: input.demoField, name: input.name, operatorName: input.operatorName, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getMasterDataLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/age-policies/master-data-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getPartnerLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/age-policies/partner-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: string) =>
    this.restService.request<any, AgePolicyWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/ccm/age-policies/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: string, input: AgePolicyUpdateDto) =>
    this.restService.request<any, AgePolicyDto>({
      method: 'PUT',
      url: `/api/ccm/age-policies/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
