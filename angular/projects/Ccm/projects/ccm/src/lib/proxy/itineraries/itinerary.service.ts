import type { GetItinerariesInput, ItineraryCreateDto, ItineraryDto, ItineraryUpdateDto, ItineraryWithNavigationPropertiesDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ItineraryService {
  apiName = 'Ccm';

  create = (input: ItineraryCreateDto) =>
    this.restService.request<any, ItineraryDto>({
      method: 'POST',
      url: '/api/ccm/itineraries',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/ccm/itineraries/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, ItineraryDto>({
      method: 'GET',
      url: `/api/ccm/itineraries/${id}`,
    },
    { apiName: this.apiName });

  getAgePolicyLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/itineraries/age-policy-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getCancellationPolicyLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/itineraries/cancellation-policy-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getDestinationLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/itineraries/destination-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getList = (input: GetItinerariesInput) =>
    this.restService.request<any, PagedResultDto<ItineraryWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/ccm/itineraries',
      params: { filterText: input.filterText, itineraryNameString: input.itineraryNameString, itineraryCode: input.itineraryCode, googleMapLink: input.googleMapLink, durationMin: input.durationMin, durationMax: input.durationMax, extendedItinerary: input.extendedItinerary, marina: input.marina, embarcationLatitude: input.embarcationLatitude, embarcationLongitude: input.embarcationLongitude, disembarkationLatitude: input.disembarkationLatitude, disembarkationLongitude: input.disembarkationLongitude, checkInTime: input.checkInTime, checkOutTime: input.checkOutTime, transferIncluded: input.transferIncluded, video: input.video, requestDurationMin: input.requestDurationMin, requestDurationMax: input.requestDurationMax, optionDurationMin: input.optionDurationMin, optionDurationMax: input.optionDurationMax, operatorName: input.operatorName, themes: input.themes, boarding: input.boarding, agePolicyId: input.agePolicyId, embarcationPort: input.embarcationPort, disembarkationPort: input.disembarkationPort, cancellationPolicy: input.cancellationPolicy, paymentPolicy: input.paymentPolicy, itineraryName: input.itineraryName, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getMasterDataLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/itineraries/master-data-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getPartnerLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/itineraries/partner-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getPaymentPolicyLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/itineraries/payment-policy-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: string) =>
    this.restService.request<any, ItineraryWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/ccm/itineraries/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: string, input: ItineraryUpdateDto) =>
    this.restService.request<any, ItineraryDto>({
      method: 'PUT',
      url: `/api/ccm/itineraries/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
