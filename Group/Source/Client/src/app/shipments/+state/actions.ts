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

export const loadItineraryRequested = createAction(
  '[Shipments] load itinerary requested'
);

export const loadItinerarySucceeded = createAction(
  '[Shipments] load itinerary request succeeded',
  props<{
    entities: { itinerary: Itinerary; legs: Leg[]; locations: Location[] };
  }>()
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
  props<{
    entities: {
      itinerary: {};
      legs: {};
      locations: {};
    };
    ids: {
      itineraryIds: string[];
      legIds: string[];
      locationIds: string[];
    };
  }>()
);

export const itineraryCreationRequestFailed = createAction(
  '[Shipments] itinerary creation request failed',
  props<{ error: any }>()
);
