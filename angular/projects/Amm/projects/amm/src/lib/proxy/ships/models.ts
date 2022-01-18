import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { DestinationDto } from '../destinations/models';
import type { CountryDto } from '../countries/models';
import type { MasterDataDto } from '../master-datas/models';
import type { ShipOperatorDto } from '../ship-operators/models';

export interface GetShipsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  shipName?: string;
  yearBuildMin?: number;
  yearBuildMax?: number;
  yearRefurbishedMin?: number;
  yearRefurbishedMax?: number;
  ensuitedCabins?: boolean;
  sharedToiletsMin?: number;
  sharedToiletsMax?: number;
  sharedShowersMin?: number;
  sharedShowersMax?: number;
  crewNoMin?: number;
  crewNoMax?: number;
  lenghtMin?: number;
  lenghtMax?: number;
  beamMin?: number;
  beamMax?: number;
  draftMin?: number;
  draftMax?: number;
  cruiseSpeedMin?: number;
  cruiseSpeedMax?: number;
  maxSpeedMin?: number;
  maxSpeedMax?: number;
  videoUrl?: string;
  useCabinDeckPosition?: boolean;
  useDeckLocation?: boolean;
  shipEnabled?: boolean;
  homePort?: string;
  flag?: string;
  shipCategory?: string;
  shipOperator?: string;
}

export interface ShipCreateDto {
  shipName: string;
  yearBuild: number;
  yearRefurbished?: number;
  ensuitedCabins: boolean;
  sharedToilets?: number;
  sharedShowers?: number;
  crewNo: number;
  lenght: number;
  beam: number;
  draft: number;
  cruiseSpeed: number;
  maxSpeed: number;
  videoUrl?: string;
  useCabinDeckPosition: boolean;
  useDeckLocation: boolean;
  shipEnabled?: boolean;
  homePort: string;
  flag: string;
  shipCategory: string;
  shipOperator?: string;
}

export interface ShipDto extends EntityDto<string> {
  shipName: string;
  yearBuild: number;
  yearRefurbished?: number;
  ensuitedCabins: boolean;
  sharedToilets?: number;
  sharedShowers?: number;
  crewNo: number;
  lenght: number;
  beam: number;
  draft: number;
  cruiseSpeed: number;
  maxSpeed: number;
  videoUrl?: string;
  useCabinDeckPosition: boolean;
  useDeckLocation: boolean;
  shipEnabled?: boolean;
  homePort: string;
  flag: string;
  shipCategory: string;
  shipOperator?: string;
}

export interface ShipUpdateDto {
  shipName: string;
  yearBuild: number;
  yearRefurbished?: number;
  ensuitedCabins: boolean;
  sharedToilets?: number;
  sharedShowers?: number;
  crewNo: number;
  lenght: number;
  beam: number;
  draft: number;
  cruiseSpeed: number;
  maxSpeed: number;
  videoUrl?: string;
  useCabinDeckPosition: boolean;
  useDeckLocation: boolean;
  shipEnabled?: boolean;
  homePort: string;
  flag: string;
  shipCategory: string;
  shipOperator?: string;
}

export interface ShipWithNavigationPropertiesDto {
  ship: ShipDto;
  destination: DestinationDto;
  country: CountryDto;
  masterData: MasterDataDto;
  shipOperator: ShipOperatorDto;
}
