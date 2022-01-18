import type { ContractCreateDto, ContractDto, ContractUpdateDto, GetContractsInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ContractService {
  apiName = 'Crm';

  create = (input: ContractCreateDto) =>
    this.restService.request<any, ContractDto>({
      method: 'POST',
      url: '/api/crm/contracts',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/crm/contracts/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, ContractDto>({
      method: 'GET',
      url: `/api/crm/contracts/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetContractsInput) =>
    this.restService.request<any, PagedResultDto<ContractDto>>({
      method: 'GET',
      url: '/api/crm/contracts',
      params: { filterText: input.filterText, operatorName: input.operatorName, seasonMin: input.seasonMin, seasonMax: input.seasonMax, isEnabledAgent: input.isEnabledAgent, isEnabledOperator: input.isEnabledOperator, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: ContractUpdateDto) =>
    this.restService.request<any, ContractDto>({
      method: 'PUT',
      url: `/api/crm/contracts/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
