import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import * as ShipmentsSelectors from '../+state/selectors';

@Injectable({
  providedIn: 'root',
})
export class ShipmentsFacadeService {
  public selectAllShipments$ = this.store$.select(
    ShipmentsSelectors.selectAllShipments$
  );
  constructor(private store$: Store) {}
}
