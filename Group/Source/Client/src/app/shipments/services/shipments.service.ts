import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ROADS_BASE_API_URL } from 'src/app/app.tokens';
import {
  CustomerInfo,
  Itinerary,
  Shipment,
  Leg,
  Location,
} from '../+state/model';
import { normalize, schema } from 'normalizr';

@Injectable({
  providedIn: 'root',
})
export class ShipmentsService {
  createItinerary(shipmentIds: string[]): Observable<Itinerary> {
    return this.client.post<Itinerary>(
      `${this.baseApiUrl}/itineraries/create`,
      shipmentIds
    );
  }
  getAllLegs(): Observable<Leg[]> {
    return this.client.get<Leg[]>(this.baseApiUrl);
  }
  getAllCustomers(): Observable<CustomerInfo[]> {
    return this.client.get<CustomerInfo[]>(this.baseApiUrl);
  }
  getAllItineraries(): Observable<Itinerary[]> {
    return this.client.get<Itinerary[]>(this.baseApiUrl);
  }
  getAllLocations(): Observable<Location[]> {
    return this.client.get<Location[]>(this.baseApiUrl);
  }
  getAllShipments(): Observable<Shipment[]> {
    return this.client.get<Shipment[]>(`${this.baseApiUrl}/all`);
  }
  constructor(
    @Inject(ROADS_BASE_API_URL) private baseApiUrl: string,
    private client: HttpClient
  ) {}

  public normalize(data) {
    const location = new schema.Entity('location');
    const leg = new schema.Entity('leg', {
      startLocation: location,
      endLocation: location,
    });
    const legs = new schema.Values(leg);
    const itinerary = new schema.Entity('itinerary', {
      legs: legs,
    });

    const normalizedData = normalize(data, itinerary);
    const entities = {
      itinerary: {},
      legs: {},
      locations: {},
    };

    entities.itinerary = normalizedData.entities.itinerary
      ? normalizedData.entities.itinerary
      : {};
    entities.legs = normalizedData.entities.leg
      ? normalizedData.entities.leg
      : {};
    entities.locations = normalizedData.entities.location
      ? normalizedData.entities.location
      : {};

    const ids = {
      itineraryIds: [],
      legIds: [],
      locationIds: [],
    };

    ids.itineraryIds = normalizedData.entities.itinerary
      ? Object.values(normalizedData.entities.itinerary).map((x) => x.id)
      : [];
    ids.legIds = normalizedData.entities.leg
      ? Object.values(normalizedData.entities.leg).map((x) => x.id)
      : [];
    ids.locationIds = normalizedData.entities.location
      ? Object.values(normalizedData.entities.location).map((x) => x.id)
      : [];

    return {
      entities,
      ids,
    };
  }
}
