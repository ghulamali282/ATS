import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { MasterDataDto } from '../master-datas/models';
import type { DestinationDto } from '../destinations/models';

export interface GetMarinasInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  marinaNameString?: string;
  latitude?: string;
  longitude?: string;
  marinaName?: string;
  destination?: string;
}

export interface MarinaCreateDto {
  marinaNameString?: string;
  latitude: string;
  longitude: string;
  marinaName: string;
  destination: string;
}

export interface MarinaDto extends EntityDto<string> {
  marinaNameString?: string;
  latitude: string;
  longitude: string;
  marinaName: string;
  destination: string;
}

export interface MarinaUpdateDto {
  marinaNameString?: string;
  latitude: string;
  longitude: string;
  marinaName: string;
  destination: string;
}

export interface MarinaWithNavigationPropertiesDto {
  marina: MarinaDto;
  masterData: MasterDataDto;
  destination: DestinationDto;
}
