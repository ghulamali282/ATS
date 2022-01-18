import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eAmmRouteNames } from '../enums/route-names';

export const BOOKING_STATUSES_BOOKING_STATUS_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/amm/booking-statuses',
        parentName: eAmmRouteNames.Amm,
        name: 'Amm::Menu:BookingStatuses',
        layout: eLayoutType.application,
        requiredPolicy: 'Amm.BookingStatuses',
      },
    ]);
  };
}
