import type { GetShipOperatorsInput, ShipOperatorCreateDto, ShipOperatorDto, ShipOperatorUpdateDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ShipOperatorService {
  apiName = 'Amm';

  create = (input: ShipOperatorCreateDto) =>
    this.restService.request<any, ShipOperatorDto>({
      method: 'POST',
      url: '/api/amm/ship-operators',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/amm/ship-operators/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, ShipOperatorDto>({
      method: 'GET',
      url: `/api/amm/ship-operators/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetShipOperatorsInput) =>
    this.restService.request<any, PagedResultDto<ShipOperatorDto>>({
      method: 'GET',
      url: '/api/amm/ship-operators',
      params: { filterText: input.filterText, operatorName: input.operatorName, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: ShipOperatorUpdateDto) =>
    this.restService.request<any, ShipOperatorDto>({
      method: 'PUT',
      url: `/api/amm/ship-operators/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
