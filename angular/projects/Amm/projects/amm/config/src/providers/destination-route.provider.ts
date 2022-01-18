import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eAmmRouteNames } from '../enums/route-names';

export const DESTINATIONS_DESTINATION_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/amm/destinations',
        parentName: eAmmRouteNames.Amm,
        name: 'Amm::Menu:Destinations',
        layout: eLayoutType.application,
        requiredPolicy: 'Amm.Destinations',
      },
    ]);
  };
}
