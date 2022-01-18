import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eAmmRouteNames } from '../enums/route-names';

export const CRUISE_REGIONS_CRUISE_REGION_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/amm/cruise-regions',
        parentName: eAmmRouteNames.Amm,
        name: 'Amm::Menu:CruiseRegions',
        layout: eLayoutType.application,
        requiredPolicy: 'Amm.CruiseRegions',
      },
    ]);
  };
}
