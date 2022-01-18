import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eCcmRouteNames } from '../enums/route-names';

export const SHIPS_SHIP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/ccm/ships',
        parentName: eCcmRouteNames.Ccm,
        name: 'Ccm::Menu:Ships',
        layout: eLayoutType.application,
        requiredPolicy: 'Ccm.Ships',
      },
    ]);
  };
}
