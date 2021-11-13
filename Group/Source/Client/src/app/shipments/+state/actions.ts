import { createAction, props } from '@ngrx/store';
import { Itinerary, Shipment, Location, CustomerInfo, Leg } from './model';

export const loadShipmentsRequested = createAction(
  '[Shipments] load shipments requested'
);

export const loadShipmentsSucceeded = createAction(
  '[Shipments] load shipments request succeeded',
  props<{ shipments: Shipment[] }>()
);

export const loadShipmentsFailed = createAction(
  '[Shipments] load shipments request failed',
  props<{ error: any }>()
);

export const loadLocationsRequested = createAction(
  '[Shipments] load locations requested'
);

export const loadLocationsSucceeded = createAction(
  '[Shipments] load locations request succeeded',
  props<{ locations: Location[] }>()
);

export const loadLocationsFailed = createAction(
  '[Shipments] load locations request failed',
  props<{ error: any }>()
);

export const loadItinerariesRequested = createAction(
  '[Shipments] load itineraries requested'
);

export const loadItinerariesSucceeded = createAction(
  '[Shipments] load itineraries request succeeded',
  props<{ itineraries: Itinerary[] }>()
);

export const loadItinerariesFailed = createAction(
  '[Shipments] load itineraries request failed',
  props<{ error: any }>()
);

export const loadCustomersRequested = createAction(
  '[Shipments] load customers requested'
);

export const loadCustomersSucceeded = createAction(
  '[Shipments] load customers request succeeded',
  props<{ customers: CustomerInfo[] }>()
);

export const loadCustomersFailed = createAction(
  '[Shipments] load customers request failed',
  props<{ error: any }>()
);

export const loadLegsRequested = createAction(
  '[Shipments] load legs requested',
  props<{ legIds: string[] }>()
);

export const loadLegsSucceeded = createAction(
  '[Shipments] load legs request succeeded',
  props<{ legs: Leg[] }>()
);

export const loadLegsFailed = createAction(
  '[Shipments] load legs request failed',
  props<{ error: any }>()
);

export const itineraryCreationRequested = createAction(
  '[Shipments] itinerary creation requested',
  props<{ shipmentIds: string[] }>()
);

export const itineraryCreationSucceeded = createAction(
  '[Shipments] itinerary creation request succeeded',
  props<{ itinerary: Itinerary }>()
);

export const itineraryCreationRequestFailed = createAction(
  '[Shipments] itinerary creation request failed',
  props<{ error: any }>()
);
