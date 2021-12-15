import { Injectable } from '@angular/core';
import { ShipmentsService } from '../services/shipments.service';
import { Actions, createEffect, ofType, OnInitEffects } from '@ngrx/effects';
import * as shipmentActions from './actions';
import { catchError, map, switchMap } from 'rxjs/operators';
import { Action } from '@ngrx/store';

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

  loadLocations$ = createEffect(() =>
    this.actions$.pipe(
      ofType(shipmentActions.loadLocationsRequested),
      switchMap(() =>
        this.shipmentsService.getAllLocations().pipe(
          map((locations) =>
            shipmentActions.loadLocationsSucceeded({ locations: locations })
          ),
          catchError(async (error) =>
            shipmentActions.loadLocationsFailed({ error: error })
          )
        )
      )
    )
  );

  loadItineraries$ = createEffect(() =>
    this.actions$.pipe(
      ofType(shipmentActions.loadItinerariesRequested),
      switchMap(() =>
        this.shipmentsService.getAllItineraries().pipe(
          map((itineraries) =>
            shipmentActions.loadItinerariesSucceeded({
              itineraries: itineraries,
            })
          ),
          catchError(async (error) =>
            shipmentActions.loadItinerariesFailed({ error: error })
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

  itineraryCreation$ = createEffect(() =>
    this.actions$.pipe(
      ofType(shipmentActions.itineraryCreationRequested),
      switchMap(({ shipmentIds }) =>
        this.shipmentsService.createItinerary(shipmentIds).pipe(
          map((itinerary) =>
            shipmentActions.itineraryCreationSucceeded({ itinerary: itinerary })
          ),
          catchError(async (error) =>
            shipmentActions.itineraryCreationRequestFailed({ error: error })
          )
        )
      )
    )
  );

  constructor(
    private actions$: Actions,
    private shipmentsService: ShipmentsService
  ) {}
  ngrxOnInitEffects(): Action {
    return shipmentActions.loadShipmentsRequested();
  }
}
