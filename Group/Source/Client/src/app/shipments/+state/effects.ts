import { Injectable } from '@angular/core';
import { ShipmentsService } from '../services/shipments.service';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as shipmentActions from './actions';
import { catchError, map, switchMap, tap } from 'rxjs/operators';

@Injectable()
export class ShipmentsEffects {
  loadShipments$ = createEffect(() =>
    this.actions$.pipe(
      ofType(shipmentActions.loadShipmentsRequested),
      switchMap(() =>
        this.shipmentsService.getAllShipments().pipe(
          map((shipments) =>
            shipmentActions.loadShipmentsSucceeded({ shipments: shipments })
          ),
          catchError(async (error) =>
            shipmentActions.loadShipmentsFailed({ error: error })
          )
        )
      )
    )
  );

  constructor(
    private actions$: Actions,
    private shipmentsService: ShipmentsService
  ) {}
}
