import type { DestinationCreateDto, DestinationDto, DestinationUpdateDto, GetDestinationsInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DestinationService {
  apiName = 'Ccm';

  create = (input: DestinationCreateDto) =>
    this.restService.request<any, DestinationDto>({
      method: 'POST',
      url: '/api/ccm/destinations',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/ccm/destinations/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, DestinationDto>({
      method: 'GET',
      url: `/api/ccm/destinations/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetDestinationsInput) =>
    this.restService.request<any, PagedResultDto<DestinationDto>>({
      method: 'GET',
      url: '/api/ccm/destinations',
      params: { filterText: input.filterText, city: input.city, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: DestinationUpdateDto) =>
    this.restService.request<any, DestinationDto>({
      method: 'PUT',
      url: `/api/ccm/destinations/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
