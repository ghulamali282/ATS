import { ModuleWithProviders, NgModule } from '@angular/core';
import { AMM_ROUTE_PROVIDERS } from './providers/route.provider';
import { APP_DEFAULTS_APP_DEFAULT_ROUTE_PROVIDER } from './providers/app-default-route.provider';
import { BOOKING_STATUSES_BOOKING_STATUS_ROUTE_PROVIDER } from './providers/booking-status-route.provider';
import { CRUISE_REGIONS_CRUISE_REGION_ROUTE_PROVIDER } from './providers/cruise-region-route.provider';
import { COUNTRIES_COUNTRY_ROUTE_PROVIDER } from './providers/country-route.provider';
import { DESTINATIONS_DESTINATION_ROUTE_PROVIDER } from './providers/destination-route.provider';
import { SHIPS_SHIP_ROUTE_PROVIDER } from './providers/ship-route.provider';
import { SHIP_DECKS_SHIP_DECK_ROUTE_PROVIDER } from './providers/ship-deck-route.provider';
import { SHIP_CABIN_TYPES_SHIP_CABIN_TYPE_ROUTE_PROVIDER } from './providers/ship-cabin-type-route.provider';
import { SHP_CABINS_SHP_CABIN_ROUTE_PROVIDER } from './providers/shp-cabin-route.provider';
import { SHIP_OPERATORS_SHIP_OPERATOR_ROUTE_PROVIDER } from './providers/ship-operator-route.provider';
import { MARINAS_MARINA_ROUTE_PROVIDER } from './providers/marina-route.provider';


@NgModule()
export class AmmConfigModule {
  static forRoot(): ModuleWithProviders<AmmConfigModule> {
    return {
      ngModule: AmmConfigModule,
      providers: [AMM_ROUTE_PROVIDERS, APP_DEFAULTS_APP_DEFAULT_ROUTE_PROVIDER, BOOKING_STATUSES_BOOKING_STATUS_ROUTE_PROVIDER, CRUISE_REGIONS_CRUISE_REGION_ROUTE_PROVIDER, COUNTRIES_COUNTRY_ROUTE_PROVIDER, DESTINATIONS_DESTINATION_ROUTE_PROVIDER, SHIPS_SHIP_ROUTE_PROVIDER, SHIP_DECKS_SHIP_DECK_ROUTE_PROVIDER, SHIP_CABIN_TYPES_SHIP_CABIN_TYPE_ROUTE_PROVIDER, SHP_CABINS_SHP_CABIN_ROUTE_PROVIDER, SHIP_OPERATORS_SHIP_OPERATOR_ROUTE_PROVIDER, MARINAS_MARINA_ROUTE_PROVIDER],
    };
  }
}
