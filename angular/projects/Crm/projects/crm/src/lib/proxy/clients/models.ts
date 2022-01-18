import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface ClientCreateDto {
  title?: string;
  firstName: string;
  secondName: string;
  gender?: string;
  clientDOB?: string;
  agePolicy?: string;
  email?: string;
  emailConfirmed?: boolean;
  country?: string;
  nacionality?: string;
  state?: string;
  zipCode?: string;
  city?: string;
  cellPhone?: string;
  cellPhoneConfirmed?: boolean;
  documentType?: string;
  documentNo?: string;
  issueDate?: string;
  expiration?: string;
  mailingList: boolean;
}

export interface ClientDto extends EntityDto<string> {
  title?: string;
  firstName: string;
  secondName: string;
  gender?: string;
  clientDOB?: string;
  agePolicy?: string;
  email?: string;
  emailConfirmed?: boolean;
  country?: string;
  nacionality?: string;
  state?: string;
  zipCode?: string;
  city?: string;
  cellPhone?: string;
  cellPhoneConfirmed?: boolean;
  documentType?: string;
  documentNo?: string;
  issueDate?: string;
  expiration?: string;
  mailingList: boolean;
}

export interface ClientUpdateDto {
  title?: string;
  firstName: string;
  secondName: string;
  gender?: string;
  clientDOB?: string;
  agePolicy?: string;
  email?: string;
  emailConfirmed?: boolean;
  country?: string;
  nacionality?: string;
  state?: string;
  zipCode?: string;
  city?: string;
  cellPhone?: string;
  cellPhoneConfirmed?: boolean;
  documentType?: string;
  documentNo?: string;
  issueDate?: string;
  expiration?: string;
  mailingList: boolean;
}

export interface GetClientsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  title?: string;
  firstName?: string;
  secondName?: string;
  gender?: string;
  clientDOBMin?: string;
  clientDOBMax?: string;
  agePolicy?: string;
  email?: string;
  emailConfirmed?: boolean;
  country?: string;
  nacionality?: string;
  state?: string;
  zipCode?: string;
  city?: string;
  cellPhone?: string;
  cellPhoneConfirmed?: boolean;
  documentType?: string;
  documentNo?: string;
  issueDateMin?: string;
  issueDateMax?: string;
  expirationMin?: string;
  expirationMax?: string;
  mailingList?: boolean;
}
