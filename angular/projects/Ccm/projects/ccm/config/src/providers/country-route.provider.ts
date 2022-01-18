import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eCcmRouteNames } from '../enums/route-names';

export const COUNTRIES_COUNTRY_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/ccm/countries',
        parentName: eCcmRouteNames.Ccm,
        name: 'Ccm::Menu:Countries',
        layout: eLayoutType.application,
        requiredPolicy: 'Ccm.Countries',
      },
    ]);
  };
}
