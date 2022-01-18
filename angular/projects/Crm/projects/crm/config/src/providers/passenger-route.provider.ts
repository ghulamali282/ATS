import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eCrmRouteNames } from '../enums/route-names';

export const PASSENGERS_PASSENGER_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/crm/passengers',
        parentName: eCrmRouteNames.Crm,
        name: 'Crm::Menu:Passengers',
        layout: eLayoutType.application,
        requiredPolicy: 'Crm.Passengers',
      },
    ]);
  };
}
