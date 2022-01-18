import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eCcmRouteNames } from '../enums/route-names';

export const ITINERARY_DETAILS_ITINERARY_DETAIL_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/ccm/itinerary-details',
        parentName: eCcmRouteNames.Ccm,
        name: 'Ccm::Menu:ItineraryDetails',
        layout: eLayoutType.application,
        requiredPolicy: 'Ccm.ItineraryDetails',
      },
    ]);
  };
}
