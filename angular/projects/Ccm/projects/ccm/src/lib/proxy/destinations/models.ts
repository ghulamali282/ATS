import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface DestinationCreateDto {
  city: string;
}

export interface DestinationDto extends EntityDto<string> {
  city: string;
}

export interface DestinationUpdateDto {
  city: string;
}

export interface GetDestinationsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  city?: string;
}
