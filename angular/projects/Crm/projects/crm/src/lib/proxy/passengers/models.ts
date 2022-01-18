import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetPassengersInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  reservation?: string;
  reservationDetail?: string;
  reservationHolder?: boolean;
  title?: string;
  firstName?: string;
  lastName?: string;
  country?: string;
  agePolicyDetail?: string;
  passengerDOBMin?: string;
  passengerDOBMax?: string;
  documentType?: string;
  documentNo?: string;
  issueDateMin?: string;
  issueDateMax?: string;
  expirationMin?: string;
  expirationMax?: string;
  passengerNote?: string;
  clientNoMin?: number;
  clientNoMax?: number;
  reduction?: string;
}

export interface PassengerCreateDto {
  reservation: string;
  reservationDetail: string;
  reservationHolder: boolean;
  title?: string;
  firstName: string;
  lastName: string;
  country?: string;
  agePolicyDetail: string;
  passengerDOB?: string;
  documentType?: string;
  documentNo?: string;
  issueDate?: string;
  expiration?: string;
  passengerNote?: string;
  clientNo: number;
  reduction: string;
}

export interface PassengerDto extends EntityDto<string> {
  reservation: string;
  reservationDetail: string;
  reservationHolder: boolean;
  title?: string;
  firstName: string;
  lastName: string;
  country?: string;
  agePolicyDetail: string;
  passengerDOB?: string;
  documentType?: string;
  documentNo?: string;
  issueDate?: string;
  expiration?: string;
  passengerNote?: string;
  clientNo: number;
  reduction: string;
}

export interface PassengerUpdateDto {
  reservation: string;
  reservationDetail: string;
  reservationHolder: boolean;
  title?: string;
  firstName: string;
  lastName: string;
  country?: string;
  agePolicyDetail: string;
  passengerDOB?: string;
  documentType?: string;
  documentNo?: string;
  issueDate?: string;
  expiration?: string;
  passengerNote?: string;
  clientNo: number;
  reduction: string;
}
