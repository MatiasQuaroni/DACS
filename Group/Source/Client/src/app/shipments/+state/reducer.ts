import { createEntityAdapter, EntityState } from "@ngrx/entity";
import { Action, createReducer } from "@ngrx/store";
import * as model from './model';

type ShipmentState = EntityState<model.Shipment>;
type LocationState = EntityState<model.Location>;
type CustomerState = EntityState<model.CustomerInfo>;
type ItineraryState = EntityState<model.Itinerary>;
type LegState = EntityState<model.Leg>;

interface State {
  shipments: ShipmentState;
  locations: LocationState;
  customers: CustomerState;
  itineraries: ItineraryState;
  legs: LegState;
  loading: boolean;
  error?: any;
}

const shipmentsAdapter = createEntityAdapter<model.Shipment>({
  selectId: (shipment) => shipment.id
});
const locationsAdapter = createEntityAdapter<model.Location>({
  selectId: (location) => location.id
});
const customersAdapter = createEntityAdapter<model.CustomerInfo>({
  selectId: (customer) => customer.id
});
const itinerariesAdapter = createEntityAdapter<model.Itinerary>({
  selectId: (itinerary) => itinerary.id
});
const legsAdapter = createEntityAdapter<model.Leg>({
  selectId: (leg) => leg.id
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
  loading: false
}

const shipmentsReducer = createReducer(initialState);


function reducer(state: State | undefined, action: Action) {
    return shipmentsReducer(state,action)
};
