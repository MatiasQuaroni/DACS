import { Action, createReducer, on } from '@ngrx/store';
import * as model from './model';
import * as shipmentActions from './actions';
import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { act } from '@ngrx/effects';

export const shipmentsFeatureKey = 'shipments';

interface ShipmentState extends EntityState<model.Shipment> {
  loading?: boolean;
}

interface CustomerState extends EntityState<model.CustomerInfo> {
  loading?: boolean;
}
interface ItineraryState extends EntityState<model.Itinerary> {
  loading?: boolean;
}

interface LocationState extends EntityState<model.Location> {
  loading?: boolean;
}
interface LegState extends EntityState<model.Leg> {
  loading?: boolean;
}

export interface State {
  shipments: ShipmentState;
  customers: CustomerState;
  locations: LocationState;
  itinerary: ItineraryState;
  legs: LegState;
  error?: any;
}

export const shipmentsAdapter = createEntityAdapter<model.Shipment>({
  selectId: (shipment) => shipment.id,
});
export const locationsAdapter = createEntityAdapter<model.Location>({
  selectId: (location) => location.id,
});
export const customersAdapter = createEntityAdapter<model.CustomerInfo>({
  selectId: (customer) => customer.id,
});
export const itinerariesAdapter = createEntityAdapter<model.Itinerary>({
  selectId: (itinerary) => itinerary.id,
});
export const legsAdapter = createEntityAdapter<model.Leg>({
  selectId: (leg) => leg.id,
});

const shipmentsInitialState = shipmentsAdapter.getInitialState();
const locationsInitialState = locationsAdapter.getInitialState();
const customersInitialState = customersAdapter.getInitialState();
const itinerariesInitialState = itinerariesAdapter.getInitialState();
const legsInitialState = legsAdapter.getInitialState();

const initialState: State = {
  shipments: shipmentsInitialState,
  customers: customersInitialState,
  locations: locationsInitialState,
  itinerary: itinerariesInitialState,
  legs: legsInitialState,
};

const shipmentsReducer = createReducer(
  initialState,
  on(shipmentActions.loadShipmentsSucceeded, (state, action) => ({
    ...state,
    shipments: {
      ...shipmentsAdapter.addMany(action.shipments, state.shipments),
      loading: false,
    },
  })),
  on(shipmentActions.loadLegsSucceeded, (state, action) => ({
    ...state,
    legs: {
      ...legsAdapter.addMany(action.legs, state.legs),
      loading: false,
    },
  })),
  on(
    shipmentActions.itineraryCreationRequested,
    (state): State => ({
      ...state,
      itinerary: { ...state.itinerary, loading: true },
    })
  ),
  on(
    shipmentActions.itineraryCreationSucceeded,
    (state, action): State => ({
      ...state,
      itinerary: {
        entities: action.entities.itinerary,
        ids: action.ids.itineraryIds,
        loading: false,
      },
      legs: {
        ids: action.ids.legIds,
        entities: action.entities.legs,
        loading: false,
      },
      locations: {
        entities: action.entities.locations,
        ids: action.ids.locationIds,
        loading: false,
      },
    })
  ),
  on(shipmentActions.loadCustomersSucceeded, (state, action) => ({
    ...state,
    customers: {
      ...customersAdapter.addMany(action.customers, state.customers),
      loading: false,
    },
  })),
  on(
    shipmentActions.loadShipmentsFailed,
    shipmentActions.loadItinerariesFailed,
    shipmentActions.loadLegsFailed,
    shipmentActions.loadCustomersFailed,
    (state, action) => ({
      ...state,
      error: action.error,
    })
  )
);

export function reducer(state: State | undefined, action: Action) {
  return shipmentsReducer(state, action);
}
