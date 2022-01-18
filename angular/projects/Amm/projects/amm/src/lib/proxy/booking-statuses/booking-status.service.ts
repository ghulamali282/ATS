import type { BookingStatusCreateDto, BookingStatusDto, BookingStatusUpdateDto, BookingStatusWithNavigationPropertiesDto, GetBookingStatusesInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { LookupDto, LookupRequestDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class BookingStatusService {
  apiName = 'Amm';

  create = (input: BookingStatusCreateDto) =>
    this.restService.request<any, BookingStatusDto>({
      method: 'POST',
      url: '/api/amm/booking-statuses',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: number) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/amm/booking-statuses/${id}`,
    },
    { apiName: this.apiName });

  get = (id: number) =>
    this.restService.request<any, BookingStatusDto>({
      method: 'GET',
      url: `/api/amm/booking-statuses/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetBookingStatusesInput) =>
    this.restService.request<any, PagedResultDto<BookingStatusWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/amm/booking-statuses',
      params: { filterText: input.filterText, statusColor: input.statusColor, bookingStatusName: input.bookingStatusName, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getMasterDataLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/amm/booking-statuses/master-data-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWithNavigationProperties = (id: number) =>
    this.restService.request<any, BookingStatusWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/amm/booking-statuses/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });

  update = (id: number, input: BookingStatusUpdateDto) =>
    this.restService.request<any, BookingStatusDto>({
      method: 'PUT',
      url: `/api/amm/booking-statuses/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
