import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eCcmRouteNames } from '../enums/route-names';

export const CHARTER_SHIPS_CHARTER_SHIP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/ccm/charter-ships',
        parentName: eCcmRouteNames.Ccm,
        name: 'Ccm::Menu:CharterShips',
        layout: eLayoutType.application,
        requiredPolicy: 'Ccm.CharterShips',
      },
    ]);
  };
}
