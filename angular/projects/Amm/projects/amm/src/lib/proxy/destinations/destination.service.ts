import type { DestinationCreateDto, DestinationDto, DestinationUpdateDto, DestinationWithNavigationPropertiesDto, GetDestinationsInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class DestinationService {
  apiName = 'Amm';

  create = (input: DestinationCreateDto) =>
    this.restService.request<any, DestinationDto>({
      method: 'POST',
      url: '/api/amm/destinations',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/amm/destinations/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, DestinationDto>({
      method: 'GET',
      url: `/api/amm/destinations/${id}`,
    },
    { apiName: this.apiName });

  getCountryLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/amm/destinations/country-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getList = (input: GetDestinationsInput) =>
    this.restService.request<any, PagedResultDto<DestinationWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/amm/destinations',
      params: { filterText: input.filterText, city: input.city, cityLocalName: input.cityLocalName, latitudeMin: input.latitudeMin, latitudeMax: input.latitudeMax, longitudeMin: input.longitudeMin, longitudeMax: input.longitudeMax, videoUrl: input.videoUrl, placeId: input.placeId, destCountry: input.destCountry, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: string) =>
    this.restService.request<any, DestinationWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/amm/destinations/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: string, input: DestinationUpdateDto) =>
    this.restService.request<any, DestinationDto>({
      method: 'PUT',
      url: `/api/amm/destinations/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
