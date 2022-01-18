import { ModuleWithProviders, NgModule } from '@angular/core';
import { CCM_ROUTE_PROVIDERS } from './providers/route.provider';
import { MASTER_DATAS_MASTER_DATA_ROUTE_PROVIDER } from './providers/master-data-route.provider';
import { PARTNERS_PARTNER_ROUTE_PROVIDER } from './providers/partner-route.provider';
import { DEPARTURE_SEASONS_DEPARTURE_SEASON_ROUTE_PROVIDER } from './providers/departure-season-route.provider';
import { DEPARTURES_DEPARTURE_ROUTE_PROVIDER } from './providers/departure-route.provider';
import { AGE_POLICIES_AGE_POLICY_ROUTE_PROVIDER } from './providers/age-policy-route.provider';
import { AGE_POLICY_DETAILS_AGE_POLICY_DETAIL_ROUTE_PROVIDER } from './providers/age-policy-detail-route.provider';
import { COUNTRIES_COUNTRY_ROUTE_PROVIDER } from './providers/country-route.provider';
import { COMPANIES_COMPANY_ROUTE_PROVIDER } from './providers/company-route.provider';
import { ITINERARIES_ITINERARY_ROUTE_PROVIDER } from './providers/itinerary-route.provider';
import { ITINERARY_DETAILS_ITINERARY_DETAIL_ROUTE_PROVIDER } from './providers/itinerary-detail-route.provider';
import { CRUISES_CRUISE_ROUTE_PROVIDER } from './providers/cruise-route.provider';
import { CHARTER_SHIPS_CHARTER_SHIP_ROUTE_PROVIDER } from './providers/charter-ship-route.provider';
import { CANCELLATION_POLICIES_CANCELLATION_POLICY_ROUTE_PROVIDER } from './providers/cancellation-policy-route.provider';
import { PAYMENT_POLICIES_PAYMENT_POLICY_ROUTE_PROVIDER } from './providers/payment-policy-route.provider';
import { DESTINATIONS_DESTINATION_ROUTE_PROVIDER } from './providers/destination-route.provider';
import { SHIPS_SHIP_ROUTE_PROVIDER } from './providers/ship-route.provider';

@NgModule()
export class CcmConfigModule {
  static forRoot(): ModuleWithProviders<CcmConfigModule> {
    return {
      ngModule: CcmConfigModule,
      providers: [CCM_ROUTE_PROVIDERS, MASTER_DATAS_MASTER_DATA_ROUTE_PROVIDER, PARTNERS_PARTNER_ROUTE_PROVIDER, DEPARTURE_SEASONS_DEPARTURE_SEASON_ROUTE_PROVIDER, DEPARTURES_DEPARTURE_ROUTE_PROVIDER, AGE_POLICIES_AGE_POLICY_ROUTE_PROVIDER, AGE_POLICY_DETAILS_AGE_POLICY_DETAIL_ROUTE_PROVIDER, COUNTRIES_COUNTRY_ROUTE_PROVIDER, COMPANIES_COMPANY_ROUTE_PROVIDER, ITINERARIES_ITINERARY_ROUTE_PROVIDER, ITINERARY_DETAILS_ITINERARY_DETAIL_ROUTE_PROVIDER, CRUISES_CRUISE_ROUTE_PROVIDER, CHARTER_SHIPS_CHARTER_SHIP_ROUTE_PROVIDER, CANCELLATION_POLICIES_CANCELLATION_POLICY_ROUTE_PROVIDER, PAYMENT_POLICIES_PAYMENT_POLICY_ROUTE_PROVIDER, DESTINATIONS_DESTINATION_ROUTE_PROVIDER, SHIPS_SHIP_ROUTE_PROVIDER],
    };
  }
}
