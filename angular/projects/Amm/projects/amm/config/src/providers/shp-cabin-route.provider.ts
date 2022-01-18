import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eAmmRouteNames } from '../enums/route-names';

export const SHP_CABINS_SHP_CABIN_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/amm/shp-cabins',
        parentName: eAmmRouteNames.Amm,
        name: 'Amm::Menu:ShpCabins',
        layout: eLayoutType.application,
        requiredPolicy: 'Amm.ShpCabins',
      },
    ]);
  };
}
