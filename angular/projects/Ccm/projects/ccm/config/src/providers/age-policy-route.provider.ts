import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eCcmRouteNames } from '../enums/route-names';

export const AGE_POLICIES_AGE_POLICY_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/ccm/age-policies',
        parentName: eCcmRouteNames.Ccm,
        name: 'Ccm::Menu:AgePolicies',
        layout: eLayoutType.application,
        requiredPolicy: 'Ccm.AgePolicies',
      },
    ]);
  };
}
