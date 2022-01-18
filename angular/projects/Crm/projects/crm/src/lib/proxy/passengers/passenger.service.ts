import type { GetPassengersInput, PassengerCreateDto, PassengerDto, PassengerUpdateDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PassengerService {
  apiName = 'Crm';

  create = (input: PassengerCreateDto) =>
    this.restService.request<any, PassengerDto>({
      method: 'POST',
      url: '/api/crm/passengers',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/crm/passengers/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, PassengerDto>({
      method: 'GET',
      url: `/api/crm/passengers/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetPassengersInput) =>
    this.restService.request<any, PagedResultDto<PassengerDto>>({
      method: 'GET',
      url: '/api/crm/passengers',
      params: { filterText: input.filterText, reservation: input.reservation, reservationDetail: input.reservationDetail, reservationHolder: input.reservationHolder, title: input.title, firstName: input.firstName, lastName: input.lastName, country: input.country, agePolicyDetail: input.agePolicyDetail, passengerDOBMin: input.passengerDOBMin, passengerDOBMax: input.passengerDOBMax, documentType: input.documentType, documentNo: input.documentNo, issueDateMin: input.issueDateMin, issueDateMax: input.issueDateMax, expirationMin: input.expirationMin, expirationMax: input.expirationMax, passengerNote: input.passengerNote, clientNoMin: input.clientNoMin, clientNoMax: input.clientNoMax, reduction: input.reduction, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: PassengerUpdateDto) =>
    this.restService.request<any, PassengerDto>({
      method: 'PUT',
      url: `/api/crm/passengers/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
