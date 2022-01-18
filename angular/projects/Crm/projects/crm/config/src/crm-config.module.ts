import { ModuleWithProviders, NgModule } from '@angular/core';
import { CRM_ROUTE_PROVIDERS } from './providers/route.provider';
import { CONTRACTS_CONTRACT_ROUTE_PROVIDER } from './providers/contract-route.provider';
import { CLIENTS_CLIENT_ROUTE_PROVIDER } from './providers/client-route.provider';
import { PASSENGERS_PASSENGER_ROUTE_PROVIDER } from './providers/passenger-route.provider';

@NgModule()
export class CrmConfigModule {
  static forRoot(): ModuleWithProviders<CrmConfigModule> {
    return {
      ngModule: CrmConfigModule,
      providers: [CRM_ROUTE_PROVIDERS, CONTRACTS_CONTRACT_ROUTE_PROVIDER, CLIENTS_CLIENT_ROUTE_PROVIDER, PASSENGERS_PASSENGER_ROUTE_PROVIDER],
    };
  }
}
