import type { GetShipDecksInput, ShipDeckCreateDto, ShipDeckDto, ShipDeckUpdateDto, ShipDeckWithNavigationPropertiesDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ShipDeckService {
  apiName = 'Amm';

  create = (input: ShipDeckCreateDto) =>
    this.restService.request<any, ShipDeckDto>({
      method: 'POST',
      url: '/api/amm/ship-decks',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/amm/ship-decks/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, ShipDeckDto>({
      method: 'GET',
      url: `/api/amm/ship-decks/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetShipDecksInput) =>
    this.restService.request<any, PagedResultDto<ShipDeckWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/amm/ship-decks',
      params: { filterText: input.filterText, shipDeckNameTEMP: input.shipDeckNameTEMP, sortOrderMin: input.sortOrderMin, sortOrderMax: input.sortOrderMax, ship: input.ship, deck: input.deck, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getMasterDataLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/amm/ship-decks/master-data-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: string) =>
    this.restService.request<any, ShipDeckWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/amm/ship-decks/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: string, input: ShipDeckUpdateDto) =>
    this.restService.request<any, ShipDeckDto>({
      method: 'PUT',
      url: `/api/amm/ship-decks/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
