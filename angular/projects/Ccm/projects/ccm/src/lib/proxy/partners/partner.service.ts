import type { GetPartnersInput, PartnerCreateDto, PartnerDto, PartnerUpdateDto, PartnerWithNavigationPropertiesDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class PartnerService {
  apiName = 'Ccm';

  create = (input: PartnerCreateDto) =>
    this.restService.request<any, PartnerDto>({
      method: 'POST',
      url: '/api/ccm/partners',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/ccm/partners/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, PartnerDto>({
      method: 'GET',
      url: `/api/ccm/partners/${id}`,
    },
    { apiName: this.apiName });

  getCountryLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/partners/country-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getList = (input: GetPartnersInput) =>
    this.restService.request<any, PagedResultDto<PartnerWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/ccm/partners',
      params: { filterText: input.filterText, partnerName: input.partnerName, address: input.address, taxNo: input.taxNo, bookingEmail: input.bookingEmail, bookingCellPhone: input.bookingCellPhone, bookingEmailConfirmed: input.bookingEmailConfirmed, bookingPhoneConfirmed: input.bookingPhoneConfirmed, email: input.email, phone: input.phone, countryName: input.countryName, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: string) =>
    this.restService.request<any, PartnerWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/ccm/partners/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: string, input: PartnerUpdateDto) =>
    this.restService.request<any, PartnerDto>({
      method: 'PUT',
      url: `/api/ccm/partners/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
