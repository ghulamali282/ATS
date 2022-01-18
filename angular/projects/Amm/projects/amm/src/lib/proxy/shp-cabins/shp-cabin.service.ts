import type { GetShpCabinsInput, ShpCabinCreateDto, ShpCabinDto, ShpCabinUpdateDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ShpCabinService {
  apiName = 'Amm';

  create = (input: ShpCabinCreateDto) =>
    this.restService.request<any, ShpCabinDto>({
      method: 'POST',
      url: '/api/amm/shp-cabins',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/amm/shp-cabins/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, ShpCabinDto>({
      method: 'GET',
      url: `/api/amm/shp-cabins/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetShpCabinsInput) =>
    this.restService.request<any, PagedResultDto<ShpCabinDto>>({
      method: 'GET',
      url: '/api/amm/shp-cabins',
      params: { filterText: input.filterText, ship: input.ship, cabinCategory: input.cabinCategory, cabinNo: input.cabinNo, cabinNoNumericMin: input.cabinNoNumericMin, cabinNoNumericMax: input.cabinNoNumericMax, bedLayout: input.bedLayout, standardCapacityMin: input.standardCapacityMin, standardCapacityMax: input.standardCapacityMax, maxCapacityMin: input.maxCapacityMin, maxCapacityMax: input.maxCapacityMax, portohole: input.portohole, window: input.window, cabinAreaMin: input.cabinAreaMin, cabinAreaMax: input.cabinAreaMax, balcon: input.balcon, balconAreaMin: input.balconAreaMin, balconAreaMax: input.balconAreaMax, isDisabled: input.isDisabled, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: ShpCabinUpdateDto) =>
    this.restService.request<any, ShpCabinDto>({
      method: 'PUT',
      url: `/api/amm/shp-cabins/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
