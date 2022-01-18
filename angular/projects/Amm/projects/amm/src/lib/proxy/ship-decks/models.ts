import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { MasterDataDto } from '../master-datas/models';

export interface GetShipDecksInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  shipDeckNameTEMP?: string;
  sortOrderMin?: number;
  sortOrderMax?: number;
  ship?: string;
  deck?: string;
}

export interface ShipDeckCreateDto {
  shipDeckNameTEMP: string;
  sortOrder: number;
  ship: string;
  deck: string;
}

export interface ShipDeckDto extends EntityDto<string> {
  shipDeckNameTEMP: string;
  sortOrder: number;
  ship: string;
  deck: string;
}

export interface ShipDeckUpdateDto {
  shipDeckNameTEMP: string;
  sortOrder: number;
  ship: string;
  deck: string;
}

export interface ShipDeckWithNavigationPropertiesDto {
  shipDeck: ShipDeckDto;
  masterData: MasterDataDto;
}
