import type { GetMarinasInput, MarinaCreateDto, MarinaDto, MarinaUpdateDto, MarinaWithNavigationPropertiesDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class MarinaService {
  apiName = 'Amm';

  create = (input: MarinaCreateDto) =>
    this.restService.request<any, MarinaDto>({
      method: 'POST',
      url: '/api/amm/marinas',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/amm/marinas/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, MarinaDto>({
      method: 'GET',
      url: `/api/amm/marinas/${id}`,
    },
    { apiName: this.apiName });

  getDestinationLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/amm/marinas/destination-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getList = (input: GetMarinasInput) =>
    this.restService.request<any, PagedResultDto<MarinaWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/amm/marinas',
      params: { filterText: input.filterText, marinaNameString: input.marinaNameString, latitude: input.latitude, longitude: input.longitude, marinaName: input.marinaName, destination: input.destination, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getMasterDataLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/amm/marinas/master-data-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: string) =>
    this.restService.request<any, MarinaWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/amm/marinas/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: string, input: MarinaUpdateDto) =>
    this.restService.request<any, MarinaDto>({
      method: 'PUT',
      url: `/api/amm/marinas/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
