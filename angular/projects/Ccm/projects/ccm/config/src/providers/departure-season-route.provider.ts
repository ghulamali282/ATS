import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eCcmRouteNames } from '../enums/route-names';

export const DEPARTURE_SEASONS_DEPARTURE_SEASON_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/ccm/departure-seasons',
        parentName: eCcmRouteNames.Ccm,
        name: 'Ccm::Menu:DepartureSeasons',
        layout: eLayoutType.application,
        requiredPolicy: 'Ccm.DepartureSeasons',
      },
    ]);
  };
}
