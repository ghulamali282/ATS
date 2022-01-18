import type { GetShipsInput, ShipCreateDto, ShipDto, ShipUpdateDto, ShipWithNavigationPropertiesDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ShipService {
  apiName = 'Amm';

  create = (input: ShipCreateDto) =>
    this.restService.request<any, ShipDto>({
      method: 'POST',
      url: '/api/amm/ships',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/amm/ships/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, ShipDto>({
      method: 'GET',
      url: `/api/amm/ships/${id}`,
    },
    { apiName: this.apiName });

  getCountryLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/amm/ships/country-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getDestinationLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/amm/ships/destination-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getList = (input: GetShipsInput) =>
    this.restService.request<any, PagedResultDto<ShipWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/amm/ships',
      params: { filterText: input.filterText, shipName: input.shipName, yearBuildMin: input.yearBuildMin, yearBuildMax: input.yearBuildMax, yearRefurbishedMin: input.yearRefurbishedMin, yearRefurbishedMax: input.yearRefurbishedMax, ensuitedCabins: input.ensuitedCabins, sharedToiletsMin: input.sharedToiletsMin, sharedToiletsMax: input.sharedToiletsMax, sharedShowersMin: input.sharedShowersMin, sharedShowersMax: input.sharedShowersMax, crewNoMin: input.crewNoMin, crewNoMax: input.crewNoMax, lenghtMin: input.lenghtMin, lenghtMax: input.lenghtMax, beamMin: input.beamMin, beamMax: input.beamMax, draftMin: input.draftMin, draftMax: input.draftMax, cruiseSpeedMin: input.cruiseSpeedMin, cruiseSpeedMax: input.cruiseSpeedMax, maxSpeedMin: input.maxSpeedMin, maxSpeedMax: input.maxSpeedMax, videoUrl: input.videoUrl, useCabinDeckPosition: input.useCabinDeckPosition, useDeckLocation: input.useDeckLocation, shipEnabled: input.shipEnabled, homePort: input.homePort, flag: input.flag, shipCategory: input.shipCategory, shipOperator: input.shipOperator, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getMasterDataLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/amm/ships/master-data-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getShipOperatorLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/amm/ships/ship-operator-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: string) =>
    this.restService.request<any, ShipWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/amm/ships/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: string, input: ShipUpdateDto) =>
    this.restService.request<any, ShipDto>({
      method: 'PUT',
      url: `/api/amm/ships/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
