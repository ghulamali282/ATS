import type { CountryCreateDto, CountryDto, CountryUpdateDto, GetCountriesInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  apiName = 'Ccm';

  create = (input: CountryCreateDto) =>
    this.restService.request<any, CountryDto>({
      method: 'POST',
      url: '/api/ccm/countries',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/ccm/countries/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, CountryDto>({
      method: 'GET',
      url: `/api/ccm/countries/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetCountriesInput) =>
    this.restService.request<any, PagedResultDto<CountryDto>>({
      method: 'GET',
      url: '/api/ccm/countries',
      params: { filterText: input.filterText, countryName: input.countryName, cultureName: input.cultureName, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: CountryUpdateDto) =>
    this.restService.request<any, CountryDto>({
      method: 'PUT',
      url: `/api/ccm/countries/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
