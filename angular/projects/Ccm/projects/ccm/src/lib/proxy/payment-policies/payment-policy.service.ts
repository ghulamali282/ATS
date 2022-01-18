import type { GetPaymentPoliciesInput, PaymentPolicyCreateDto, PaymentPolicyDto, PaymentPolicyUpdateDto, PaymentPolicyWithNavigationPropertiesDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class PaymentPolicyService {
  apiName = 'Ccm';

  create = (input: PaymentPolicyCreateDto) =>
    this.restService.request<any, PaymentPolicyDto>({
      method: 'POST',
      url: '/api/ccm/payment-policies',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/ccm/payment-policies/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, PaymentPolicyDto>({
      method: 'GET',
      url: `/api/ccm/payment-policies/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetPaymentPoliciesInput) =>
    this.restService.request<any, PagedResultDto<PaymentPolicyWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/ccm/payment-policies',
      params: { filterText: input.filterText, delayedDepositAt: input.delayedDepositAt, depositMin: input.depositMin, depositMax: input.depositMax, depositAtReservation: input.depositAtReservation, depositType: input.depositType, finalPaymentDueDaysMin: input.finalPaymentDueDaysMin, finalPaymentDueDaysMax: input.finalPaymentDueDaysMax, fullPaymentRequiredDaysMin: input.fullPaymentRequiredDaysMin, fullPaymentRequiredDaysMax: input.fullPaymentRequiredDaysMax, policyString: input.policyString, operatorName: input.operatorName, policyName: input.policyName, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getMasterDataLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/payment-policies/master-data-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getPartnerLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/payment-policies/partner-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: string) =>
    this.restService.request<any, PaymentPolicyWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/ccm/payment-policies/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: string, input: PaymentPolicyUpdateDto) =>
    this.restService.request<any, PaymentPolicyDto>({
      method: 'PUT',
      url: `/api/ccm/payment-policies/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
