import type { GetShipsInput, ShipCreateDto, ShipDto, ShipUpdateDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ShipService {
  apiName = 'Ccm';

  create = (input: ShipCreateDto) =>
    this.restService.request<any, ShipDto>({
      method: 'POST',
      url: '/api/ccm/ships',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/ccm/ships/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, ShipDto>({
      method: 'GET',
      url: `/api/ccm/ships/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetShipsInput) =>
    this.restService.request<any, PagedResultDto<ShipDto>>({
      method: 'GET',
      url: '/api/ccm/ships',
      params: { filterText: input.filterText, shipName: input.shipName, shipCategory: input.shipCategory, shipOperator: input.shipOperator, type: input.type, flag: input.flag, homePort: input.homePort, manufacturer: input.manufacturer, model: input.model, yearBuildMin: input.yearBuildMin, yearBuildMax: input.yearBuildMax, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: ShipUpdateDto) =>
    this.restService.request<any, ShipDto>({
      method: 'PUT',
      url: `/api/ccm/ships/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
