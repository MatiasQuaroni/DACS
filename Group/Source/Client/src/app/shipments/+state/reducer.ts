import { Action, createReducer, on } from '@ngrx/store';
import * as model from './model';
import * as shipmentActions from './actions';
import { createEntityAdapter, EntityState } from '@ngrx/entity';

export const shipmentsFeatureKey = 'shipments';

interface ShipmentState extends EntityState<model.Shipment> {
  loading?: boolean;
}
interface LocationState extends EntityState<model.Location> {
  loading?: boolean;
}
interface CustomerState extends EntityState<model.CustomerInfo> {
  loading?: boolean;
}
interface ItineraryState extends EntityState<model.Itinerary> {
  loading?: boolean;
}
interface LegState extends EntityState<model.Leg> {
  loading?: boolean;
}

interface State {
  shipments: ShipmentState;
  locations: LocationState;
  customers: CustomerState;
  itineraries: ItineraryState;
  legs: LegState;
  error?: any;
}

const shipmentsAdapter = createEntityAdapter<model.Shipment>({
  selectId: (shipment) => shipment.id,
});
const locationsAdapter = createEntityAdapter<model.Location>({
  selectId: (location) => location.id,
});
const customersAdapter = createEntityAdapter<model.CustomerInfo>({
  selectId: (customer) => customer.id,
});
const itinerariesAdapter = createEntityAdapter<model.Itinerary>({
  selectId: (itinerary) => itinerary.id,
});
const legsAdapter = createEntityAdapter<model.Leg>({
  selectId: (leg) => leg.id,
});

const shipmentsInitialState = shipmentsAdapter.getInitialState();
const locationsInitialState = locationsAdapter.getInitialState();
const customersInitialState = customersAdapter.getInitialState();
const itinerariesInitialState = itinerariesAdapter.getInitialState();
const legsInitialState = legsAdapter.getInitialState();

const initialState: State = {
  shipments: shipmentsInitialState,
  locations: locationsInitialState,
  customers: customersInitialState,
  itineraries: itinerariesInitialState,
  legs: legsInitialState,
};

const shipmentsReducer = createReducer(
  initialState,
  on(shipmentActions.loadItinerariesRequested, (state, action) => ({
    ...state,
    itineraries: {
      ...state.itineraries,
      loading: true,
    },
  })),
  on(shipmentActions.loadShipmentsSucceeded, (state, action) => ({
    ...state,
    shipments: {
      ...shipmentsAdapter.addMany(action.shipments, state.shipments),
      loading: false,
    },
  })),
  on(shipmentActions.loadLocationsSucceeded, (state, action) => ({
    ...state,
    locations: {
      ...locationsAdapter.addMany(action.locations, state.locations),
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
  on(shipmentActions.loadItinerariesSucceeded, (state, action) => ({
    ...state,
    itineraries: {
      ...itinerariesAdapter.addMany(action.itineraries, state.itineraries),
      loading: false,
    },
  })),
  on(shipmentActions.itineraryCreationRequested, (state) => ({
    ...state,
    itineraries: {
      ...state.itineraries,
      loading: true,
    }
  })),
  on(shipmentActions.itineraryCreationSucceeded, (state, action) => ({
    ...state,
    itineraries: {
      ...itinerariesAdapter.addOne(action.itinerary, state.itineraries),
      loading: false,
    }
  })),
  on(shipmentActions.loadCustomersSucceeded, (state, action) => ({
    ...state,
    customers: {
      ...customersAdapter.addMany(action.customers, state.customers),
      loading: false,
    },
  })),
  on(
    shipmentActions.loadShipmentsFailed,
    shipmentActions.loadLocationsFailed,
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
