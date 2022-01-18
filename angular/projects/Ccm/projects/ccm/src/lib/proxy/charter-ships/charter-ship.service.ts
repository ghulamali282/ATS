import type { CharterShipCreateDto, CharterShipDto, CharterShipUpdateDto, GetCharterShipsInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CharterShipService {
  apiName = 'Ccm';

  create = (input: CharterShipCreateDto) =>
    this.restService.request<any, CharterShipDto>({
      method: 'POST',
      url: '/api/ccm/charter-ships',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/ccm/charter-ships/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, CharterShipDto>({
      method: 'GET',
      url: `/api/ccm/charter-ships/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetCharterShipsInput) =>
    this.restService.request<any, PagedResultDto<CharterShipDto>>({
      method: 'GET',
      url: '/api/ccm/charter-ships',
      params: { filterText: input.filterText, operatorName: input.operatorName, seasonMin: input.seasonMin, seasonMax: input.seasonMax, shipNamePrefix: input.shipNamePrefix, ship: input.ship, itinerary: input.itinerary, tabs: input.tabs, video: input.video, featured: input.featured, freeInternetOnBoard: input.freeInternetOnBoard, internet: input.internet, transferIncluded: input.transferIncluded, enabledByUser: input.enabledByUser, disabledBySystemMin: input.disabledBySystemMin, disabledBySystemMax: input.disabledBySystemMax, b2B: input.b2B, b2C: input.b2C, b2B_Agent: input.b2B_Agent, b2C_Agent: input.b2C_Agent, shipAmenities: input.shipAmenities, shipArticles: input.shipArticles, shipPhotos: input.shipPhotos, cabinAmenities: input.cabinAmenities, cabinArticles: input.cabinArticles, cabinPhotos: input.cabinPhotos, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: CharterShipUpdateDto) =>
    this.restService.request<any, CharterShipDto>({
      method: 'PUT',
      url: `/api/ccm/charter-ships/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
