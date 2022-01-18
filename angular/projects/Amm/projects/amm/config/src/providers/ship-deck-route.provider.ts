import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eAmmRouteNames } from '../enums/route-names';

export const SHIP_DECKS_SHIP_DECK_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/amm/ship-decks',
        parentName: eAmmRouteNames.Amm,
        name: 'Amm::Menu:ShipDecks',
        layout: eLayoutType.application,
        requiredPolicy: 'Amm.ShipDecks',
      },
    ]);
  };
}
