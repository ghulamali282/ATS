import type { GetItineraryDetailsInput, ItineraryDetailCreateDto, ItineraryDetailDto, ItineraryDetailUpdateDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ItineraryDetailService {
  apiName = 'Ccm';

  create = (input: ItineraryDetailCreateDto) =>
    this.restService.request<any, ItineraryDetailDto>({
      method: 'POST',
      url: '/api/ccm/itinerary-details',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/ccm/itinerary-details/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, ItineraryDetailDto>({
      method: 'GET',
      url: `/api/ccm/itinerary-details/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetItineraryDetailsInput) =>
    this.restService.request<any, PagedResultDto<ItineraryDetailDto>>({
      method: 'GET',
      url: '/api/ccm/itinerary-details',
      params: { filterText: input.filterText, itinerary: input.itinerary, name: input.name, dayMin: input.dayMin, dayMax: input.dayMax, ports: input.ports, alternativePorts: input.alternativePorts, welcomeDrink: input.welcomeDrink, welcomeSnack: input.welcomeSnack, breakfast: input.breakfast, brunch: input.brunch, lunch: input.lunch, afternoonSnack: input.afternoonSnack, dinner: input.dinner, captainDinner: input.captainDinner, liveMusic: input.liveMusic, wineTasting: input.wineTasting, overnightOnAnchor: input.overnightOnAnchor, overnightAtMarina: input.overnightAtMarina, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: ItineraryDetailUpdateDto) =>
    this.restService.request<any, ItineraryDetailDto>({
      method: 'PUT',
      url: `/api/ccm/itinerary-details/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
