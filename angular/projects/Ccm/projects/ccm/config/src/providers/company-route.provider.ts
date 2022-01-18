import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eCcmRouteNames } from '../enums/route-names';

export const COMPANIES_COMPANY_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/ccm/companies',
        parentName: eCcmRouteNames.Ccm,
        name: 'Ccm::Menu:Companies',
        layout: eLayoutType.application,
        requiredPolicy: 'Ccm.Companies',
      },
    ]);
  };
}
