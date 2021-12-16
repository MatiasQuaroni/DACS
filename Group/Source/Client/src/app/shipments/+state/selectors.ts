import { createFeatureSelector, createSelector } from '@ngrx/store';
import { Leg } from './model';
import * as fromShipments from './reducer';

interface LegWithLocation {
  leg: Leg;
  startLocation: Location;
  endLocation: Location;
}

export const selectShipmentState = createFeatureSelector<fromShipments.State>(
  fromShipments.shipmentsFeatureKey
);

const shipmentsSelectors = fromShipments.shipmentsAdapter.getSelectors();

const itinerariesSelector = fromShipments.itinerariesAdapter.getSelectors();

const customersSelectors = fromShipments.customersAdapter.getSelectors();

const locationsSelectors = fromShipments.locationsAdapter.getSelectors();

const legsSelectors = fromShipments.legsAdapter.getSelectors();

export const selectItineraries$ = createSelector(selectShipmentState, (state) =>
  itinerariesSelector.selectAll(state.itinerary)
);

export const selectItinerary$ = createSelector(
  selectItineraries$,
  (itineraries) => itineraries[0]
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

export const selectAllLocations$ = createSelector(
  selectShipmentState,
  (state) => locationsSelectors.selectAll(state.locations)
);

export const selectAllLocationEntities$ = createSelector(
  selectShipmentState,
  (state) => locationsSelectors.selectEntities(state.locations)
);

export const selectLegById = (id: string) =>
  createSelector(selectAllLegEntities$, (legs) => legs[id]);

export const selectLegWithLocations = (id: string) =>
  createSelector(
    selectLegById(id),
    selectAllLocationEntities$,
    (leg, locations) => {
      locations[leg.startLocationId], locations[leg.endLocationId];
    }
  );
