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

const selectAllShipmentEntities$ = createSelector(
  selectShipmentState,
  (state) => shipmentsSelectors.selectEntities(state.shipments)
);

const selectAllShipments$ = createSelector(selectShipmentState, (state) =>
  shipmentsSelectors.selectAll(state.shipments)
);

const selectAllItineraryEntities$ = createSelector(
  selectShipmentState,
  (state) => itinerariesSelector.selectEntities(state.itineraries)
);

const selectAllItineraries$ = createSelector(selectShipmentState, (state) =>
  itinerariesSelector.selectAll(state.itineraries)
);

const selectAllCustomerEntities$ = createSelector(
  selectShipmentState,
  (state) => customersSelectors.selectEntities(state.customers)
);

const selectAllCustomers$ = createSelector(selectShipmentState, (state) =>
  customersSelectors.selectAll(state.customers)
);

const selectAllLocationEntities$ = createSelector(
  selectShipmentState,
  (state) => locationsSelectors.selectEntities(state.locations)
);

const selectAllLocations$ = createSelector(selectShipmentState, (state) =>
  locationsSelectors.selectAll(state.locations)
);

const selectAllLegEntities$ = createSelector(selectShipmentState, (state) =>
  legsSelectors.selectEntities(state.legs)
);

const selectAllLegs$ = createSelector(selectShipmentState, (state) =>
  legsSelectors.selectAll(state.legs)
);
