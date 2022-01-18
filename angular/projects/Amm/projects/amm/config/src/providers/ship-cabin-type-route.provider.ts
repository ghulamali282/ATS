import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eAmmRouteNames } from '../enums/route-names';

export const SHIP_CABIN_TYPES_SHIP_CABIN_TYPE_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/amm/ship-cabin-types',
        parentName: eAmmRouteNames.Amm,
        name: 'Amm::Menu:ShipCabinTypes',
        layout: eLayoutType.application,
        requiredPolicy: 'Amm.ShipCabinTypes',
      },
    ]);
  };
}
