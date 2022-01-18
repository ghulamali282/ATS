import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { MasterDataDto } from '../master-datas/models';

export interface BookingStatusCreateDto {
  statusColor: string;
  bookingStatusName: string;
}

export interface BookingStatusDto extends EntityDto<number> {
  statusColor: string;
  bookingStatusName: string;
}

export interface BookingStatusUpdateDto {
  statusColor: string;
  bookingStatusName: string;
}

export interface BookingStatusWithNavigationPropertiesDto {
  bookingStatus: BookingStatusDto;
  masterData: MasterDataDto;
}

export interface GetBookingStatusesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  statusColor?: string;
  bookingStatusName?: string;
}
