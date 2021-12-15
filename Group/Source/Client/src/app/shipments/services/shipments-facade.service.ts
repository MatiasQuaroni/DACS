import { Injectable } from '@angular/core';
import { Action, Store } from '@ngrx/store';
import * as ShipmentsSelectors from '../+state/selectors';

@Injectable({
  providedIn: 'root',
})
export class ShipmentsFacadeService {
  public selectAllShipments$ = this.store$.select(
    ShipmentsSelectors.selectAllShipments$
  );

  public selectItinerary$ = this.store$.select(
    ShipmentsSelectors.selectItinerary$
  );

  public selectLegs$ = this.store$.select(ShipmentsSelectors.selectAllLegs$);

  public selectLocations$ = this.store$.select(
    ShipmentsSelectors.selectAllLocations$
  );

  public dispatch(action: Action) {
    this.store$.dispatch(action);
  }
  constructor(private store$: Store) {}
}
