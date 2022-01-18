import type { GetShipCabinTypesInput, ShipCabinTypeCreateDto, ShipCabinTypeDto, ShipCabinTypeUpdateDto, ShipCabinTypeWithNavigationPropertiesDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ShipCabinTypeService {
  apiName = 'Amm';

  create = (input: ShipCabinTypeCreateDto) =>
    this.restService.request<any, ShipCabinTypeDto>({
      method: 'POST',
      url: '/api/amm/ship-cabin-types',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/amm/ship-cabin-types/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, ShipCabinTypeDto>({
      method: 'GET',
      url: `/api/amm/ship-cabin-types/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetShipCabinTypesInput) =>
    this.restService.request<any, PagedResultDto<ShipCabinTypeWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/amm/ship-cabin-types',
      params: { filterText: input.filterText, ship: input.ship, sortOrderMin: input.sortOrderMin, sortOrderMax: input.sortOrderMax, cabinCategory: input.cabinCategory, deck: input.deck, deckLocation: input.deckLocation, deckPosition: input.deckPosition, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getMasterDataLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/amm/ship-cabin-types/master-data-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getShipDeckLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/amm/ship-cabin-types/ship-deck-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: string) =>
    this.restService.request<any, ShipCabinTypeWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/amm/ship-cabin-types/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: string, input: ShipCabinTypeUpdateDto) =>
    this.restService.request<any, ShipCabinTypeDto>({
      method: 'PUT',
      url: `/api/amm/ship-cabin-types/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
