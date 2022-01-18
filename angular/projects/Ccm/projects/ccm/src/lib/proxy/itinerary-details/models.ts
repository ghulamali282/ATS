import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetItineraryDetailsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  itinerary?: string;
  name?: string;
  dayMin?: number;
  dayMax?: number;
  ports?: string;
  alternativePorts?: string;
  welcomeDrink?: boolean;
  welcomeSnack?: boolean;
  breakfast?: boolean;
  brunch?: boolean;
  lunch?: boolean;
  afternoonSnack?: boolean;
  dinner?: boolean;
  captainDinner?: boolean;
  liveMusic?: boolean;
  wineTasting?: boolean;
  overnightOnAnchor?: boolean;
  overnightAtMarina?: boolean;
}

export interface ItineraryDetailCreateDto {
  itinerary: string;
  name: string;
  day: number;
  ports: string;
  alternativePorts?: string;
  welcomeDrink: boolean;
  welcomeSnack: boolean;
  breakfast: boolean;
  brunch: boolean;
  lunch: boolean;
  afternoonSnack: boolean;
  dinner: boolean;
  captainDinner: boolean;
  liveMusic: boolean;
  wineTasting: boolean;
  overnightOnAnchor: boolean;
  overnightAtMarina: boolean;
}

export interface ItineraryDetailDto extends EntityDto<string> {
  itinerary: string;
  name: string;
  day: number;
  ports: string;
  alternativePorts?: string;
  welcomeDrink: boolean;
  welcomeSnack: boolean;
  breakfast: boolean;
  brunch: boolean;
  lunch: boolean;
  afternoonSnack: boolean;
  dinner: boolean;
  captainDinner: boolean;
  liveMusic: boolean;
  wineTasting: boolean;
  overnightOnAnchor: boolean;
  overnightAtMarina: boolean;
}

export interface ItineraryDetailUpdateDto {
  itinerary: string;
  name: string;
  day: number;
  ports: string;
  alternativePorts?: string;
  welcomeDrink: boolean;
  welcomeSnack: boolean;
  breakfast: boolean;
  brunch: boolean;
  lunch: boolean;
  afternoonSnack: boolean;
  dinner: boolean;
  captainDinner: boolean;
  liveMusic: boolean;
  wineTasting: boolean;
  overnightOnAnchor: boolean;
  overnightAtMarina: boolean;
}
