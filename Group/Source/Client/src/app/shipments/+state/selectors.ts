import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromShipments from './reducer';

export const selectShipmentState = createFeatureSelector<fromShipments.State>(
  fromShipments.shipmentsFeatureKey
);

const shipmentsSelectors = fromShipments.shipmentsAdapter.getSelectors();

const itinerariesSelector = fromShipments.itinerariesAdapter.getSelectors();

const customersSelectors = fromShipments.customersAdapter.getSelectors();

const locationsSelectors = fromShipments.locationsAdapter.getSelectors();

const legsSelectors = fromShipments.legsAdapter.getSelectors();

export const selectItinerary$ = createSelector(selectShipmentState, (state) =>
  itinerariesSelector.selectAll(state.itinerary)
);

const selectAllShipmentEntities$ = createSelector(
  selectShipmentState,
  (state) => shipmentsSelectors.selectEntities(state.shipments)
);

export const selectAllShipments$ = createSelector(
  selectShipmentState,
  (state) => shipmentsSelectors.selectAll(state.shipments)
);

const selectAllCustomerEntities$ = createSelector(
  selectShipmentState,
  (state) => customersSelectors.selectEntities(state.customers)
);

const selectAllCustomers$ = createSelector(selectShipmentState, (state) =>
  customersSelectors.selectAll(state.customers)
);

export const selectAllLegEntities$ = createSelector(
  selectShipmentState,
  (state) => legsSelectors.selectEntities(state.legs)
);

export const selectAllLegs$ = createSelector(selectShipmentState, (state) =>
  legsSelectors.selectAll(state.legs)
);
