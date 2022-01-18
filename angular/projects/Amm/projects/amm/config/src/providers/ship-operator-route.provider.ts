import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eAmmRouteNames } from '../enums/route-names';

export const SHIP_OPERATORS_SHIP_OPERATOR_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/amm/ship-operators',
        parentName: eAmmRouteNames.Amm,
        name: 'Amm::Menu:ShipOperators',
        layout: eLayoutType.application,
        requiredPolicy: 'Amm.ShipOperators',
      },
    ]);
  };
}
