import type { DepartureCreateDto, DepartureDto, DepartureUpdateDto, DepartureWithNavigationPropertiesDto, GetDeparturesInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class DepartureService {
  apiName = 'Ccm';

  create = (input: DepartureCreateDto) =>
    this.restService.request<any, DepartureDto>({
      method: 'POST',
      url: '/api/ccm/departures',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/ccm/departures/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, DepartureDto>({
      method: 'GET',
      url: `/api/ccm/departures/${id}`,
    },
    { apiName: this.apiName });

  getDepartureSeasonLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/departures/departure-season-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getList = (input: GetDeparturesInput) =>
    this.restService.request<any, PagedResultDto<DepartureWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/ccm/departures',
      params: { filterText: input.filterText, departuresArray: input.departuresArray, seasonGroup: input.seasonGroup, partner: input.partner, seasonName: input.seasonName, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getPartnerLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/ccm/departures/partner-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: string) =>
    this.restService.request<any, DepartureWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/ccm/departures/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: string, input: DepartureUpdateDto) =>
    this.restService.request<any, DepartureDto>({
      method: 'PUT',
      url: `/api/ccm/departures/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
