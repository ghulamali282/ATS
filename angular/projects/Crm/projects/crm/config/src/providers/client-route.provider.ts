import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eCrmRouteNames } from '../enums/route-names';

export const CLIENTS_CLIENT_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/crm/clients',
        parentName: eCrmRouteNames.Crm,
        name: 'Crm::Menu:Clients',
        layout: eLayoutType.application,
        requiredPolicy: 'Crm.Clients',
      },
    ]);
  };
}
