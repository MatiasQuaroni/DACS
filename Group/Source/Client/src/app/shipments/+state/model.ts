export interface Shipment {
  id: string;
  trackingNumber: string;
  weight: number;
  precautions?: string;
  arrivalDate?: Date;
  estimatedArrivalDate: Date;
  destinationAddressId: string;
  customerInfoId: string;
}

export interface Location {
  id: string;
  postalCode: string;
  coordinates: string;
  address: string;
  floor: number;
  number: number;
}

export interface CustomerInfo {
  id: string;
  name: string;
  emailAddress: string;
  dni: string;
  phoneNumber: string;
}

export interface Itinerary {
  id: string;
  isComplete: boolean;
  startDate: Date;
  endDate?: Date;
  legs: string[];
}

export interface Leg {
  id: string;
  startLocationId: string;
  endLocationId: string;
}
