import type { ClientCreateDto, ClientDto, ClientUpdateDto, GetClientsInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ClientService {
  apiName = 'Crm';

  create = (input: ClientCreateDto) =>
    this.restService.request<any, ClientDto>({
      method: 'POST',
      url: '/api/crm/clients',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/crm/clients/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, ClientDto>({
      method: 'GET',
      url: `/api/crm/clients/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetClientsInput) =>
    this.restService.request<any, PagedResultDto<ClientDto>>({
      method: 'GET',
      url: '/api/crm/clients',
      params: { filterText: input.filterText, title: input.title, firstName: input.firstName, secondName: input.secondName, gender: input.gender, clientDOBMin: input.clientDOBMin, clientDOBMax: input.clientDOBMax, agePolicy: input.agePolicy, email: input.email, emailConfirmed: input.emailConfirmed, country: input.country, nacionality: input.nacionality, state: input.state, zipCode: input.zipCode, city: input.city, cellPhone: input.cellPhone, cellPhoneConfirmed: input.cellPhoneConfirmed, documentType: input.documentType, documentNo: input.documentNo, issueDateMin: input.issueDateMin, issueDateMax: input.issueDateMax, expirationMin: input.expirationMin, expirationMax: input.expirationMax, mailingList: input.mailingList, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: ClientUpdateDto) =>
    this.restService.request<any, ClientDto>({
      method: 'PUT',
      url: `/api/crm/clients/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
