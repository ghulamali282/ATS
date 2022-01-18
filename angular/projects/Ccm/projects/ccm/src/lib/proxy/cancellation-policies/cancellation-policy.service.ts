import type { CancellationPolicyCreateDto, CancellationPolicyDto, CancellationPolicyUpdateDto, CancellationPolicyWithNavigationPropertiesDto, GetCancellationPoliciesInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CancellationPolicyService {
  apiName = 'Ccm';

  create = (input: CancellationPolicyCreateDto) =>
    this.restService.request<any, CancellationPolicyDto>({
      method: 'POST',
      url: '/api/ccm/cancellation-policies',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/ccm/cancellation-policies/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, CancellationPolicyDto>({
      method: 'GET',
      url: `/api/ccm/cancellation-policies/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetCancellationPoliciesInput) =>
    this.restService.request<any, PagedResultDto<CancellationPolicyWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/ccm/cancellation-policies',
      params: { filterText: input.filterText, nameString: input.nameString, operatorName: input.operatorName, policyName: input.policyName, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getMasterDataLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/cancellation-policies/master-data-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getPartnerLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/cancellation-policies/partner-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: string) =>
    this.restService.request<any, CancellationPolicyWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/ccm/cancellation-policies/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: string, input: CancellationPolicyUpdateDto) =>
    this.restService.request<any, CancellationPolicyDto>({
      method: 'PUT',
      url: `/api/ccm/cancellation-policies/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
