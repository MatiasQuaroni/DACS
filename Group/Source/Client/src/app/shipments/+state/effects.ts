import { Injectable } from '@angular/core';
import { ShipmentsService } from '../services/shipments.service';
import { Actions, createEffect, ofType, OnInitEffects } from '@ngrx/effects';
import * as shipmentActions from './actions';
import { catchError, map, switchMap, tap } from 'rxjs/operators';
import { Action } from '@ngrx/store';
import { Router } from '@angular/router';

@Injectable()
export class ShipmentsEffects implements OnInitEffects {
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

  loadCustomers$ = createEffect(() =>
    this.actions$.pipe(
      ofType(shipmentActions.loadCustomersRequested),
      switchMap(() =>
        this.shipmentsService.getAllCustomers().pipe(
          map((customers) =>
            shipmentActions.loadCustomersSucceeded({ customers: customers })
          ),
          catchError(async (error) =>
            shipmentActions.loadCustomersFailed({ error: error })
          )
        )
      )
    )
  );

  loadLegs$ = createEffect(() =>
    this.actions$.pipe(
      ofType(shipmentActions.loadLegsRequested),
      switchMap(() =>
        this.shipmentsService.getAllLegs().pipe(
          map((legs) => shipmentActions.loadLegsSucceeded({ legs: legs })),
          catchError(async (error) =>
            shipmentActions.loadLegsFailed({ error: error })
          )
        )
      )
    )
  );

  itineraryRequested$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(shipmentActions.itineraryCreationRequested),
        tap(() => this.router.navigate(['/roads/shipments/itinerary']))
      ),
    { dispatch: false }
  );

  itineraryCreation$ = createEffect(() =>
    this.actions$.pipe(
      ofType(shipmentActions.itineraryCreationRequested),
      switchMap(({ shipmentIds }) =>
        this.shipmentsService.createItinerary(shipmentIds).pipe(
          map((itinerary) => {
            let data = this.shipmentsService.normalize(itinerary);
            console.log(data);
            return shipmentActions.itineraryCreationSucceeded({
              entities: data.entities,
              ids: data.ids,
            });
          }),
          catchError(async (error) =>
            shipmentActions.itineraryCreationRequestFailed({ error: error })
          )
        )
      )
    )
  );

  constructor(
    private actions$: Actions,
    private shipmentsService: ShipmentsService,
    private router: Router
  ) {}
  ngrxOnInitEffects(): Action {
    return shipmentActions.loadShipmentsRequested();
  }
}
