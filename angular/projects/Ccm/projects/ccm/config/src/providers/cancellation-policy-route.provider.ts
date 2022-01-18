import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eCcmRouteNames } from '../enums/route-names';

export const CANCELLATION_POLICIES_CANCELLATION_POLICY_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/ccm/cancellation-policies',
        parentName: eCcmRouteNames.Ccm,
        name: 'Ccm::Menu:CancellationPolicies',
        layout: eLayoutType.application,
        requiredPolicy: 'Ccm.CancellationPolicies',
      },
    ]);
  };
}
