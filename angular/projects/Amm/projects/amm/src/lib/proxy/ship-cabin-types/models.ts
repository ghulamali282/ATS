import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { MasterDataDto } from '../master-datas/models';
import type { ShipDeckDto } from '../ship-decks/models';

export interface GetShipCabinTypesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  ship?: string;
  sortOrderMin?: number;
  sortOrderMax?: number;
  cabinCategory?: string;
  deck?: string;
  deckLocation?: string;
  deckPosition?: string;
}

export interface ShipCabinTypeCreateDto {
  ship: string;
  sortOrder: number;
  cabinCategory: string;
  deck: string;
  deckLocation: string;
  deckPosition?: string;
}

export interface ShipCabinTypeDto extends EntityDto<string> {
  ship: string;
  sortOrder: number;
  cabinCategory: string;
  deck: string;
  deckLocation: string;
  deckPosition?: string;
}

export interface ShipCabinTypeUpdateDto {
  ship: string;
  sortOrder: number;
  cabinCategory: string;
  deck: string;
  deckLocation: string;
  deckPosition?: string;
}

export interface ShipCabinTypeWithNavigationPropertiesDto {
  shipCabinType: ShipCabinTypeDto;
  masterData: MasterDataDto;
  shipDeck: ShipDeckDto;
}
