import type { CruiseCreateDto, CruiseDto, CruiseUpdateDto, CruiseWithNavigationPropertiesDto, GetCruisesInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CruiseService {
  apiName = 'Ccm';

  create = (input: CruiseCreateDto) =>
    this.restService.request<any, CruiseDto>({
      method: 'POST',
      url: '/api/ccm/cruises',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/ccm/cruises/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, CruiseDto>({
      method: 'GET',
      url: `/api/ccm/cruises/${id}`,
    },
    { apiName: this.apiName });

  getItineraryLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/cruises/itinerary-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getList = (input: GetCruisesInput) =>
    this.restService.request<any, PagedResultDto<CruiseWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/ccm/cruises',
      params: { filterText: input.filterText, seasonMin: input.seasonMin, seasonMax: input.seasonMax, cruiseEnabled: input.cruiseEnabled, featured: input.featured, freeInternetOnBoard: input.freeInternetOnBoard, internetOnBoard: input.internetOnBoard, video: input.video, b2B: input.b2B, b2C: input.b2C, b2B_Agent: input.b2B_Agent, b2C_Agent: input.b2C_Agent, cruiseDescriptions: input.cruiseDescriptions, shipAmenities: input.shipAmenities, shipArticles: input.shipArticles, shipPhotos: input.shipPhotos, cabinAmenities: input.cabinAmenities, cabinArticles: input.cabinArticles, cabinPhotos: input.cabinPhotos, ship: input.ship, itinerary: input.itinerary, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getShipLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/cruises/ship-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: string) =>
    this.restService.request<any, CruiseWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/ccm/cruises/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: string, input: CruiseUpdateDto) =>
    this.restService.request<any, CruiseDto>({
      method: 'PUT',
      url: `/api/ccm/cruises/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
