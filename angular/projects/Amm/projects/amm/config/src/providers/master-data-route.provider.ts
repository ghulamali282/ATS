import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eAmmRouteNames } from '../enums/route-names';

export const MASTER_DATAS_MASTER_DATA_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/amm/master-datas',
        parentName: eAmmRouteNames.Amm,
        name: 'Amm::Menu:MasterDatas',
        layout: eLayoutType.application,
        requiredPolicy: 'Amm.MasterDatas',
      },
    ]);
  };
}
