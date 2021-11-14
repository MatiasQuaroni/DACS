import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  CustomerInfo,
  Itinerary,
  Shipment,
  Leg,
  Location,
} from '../+state/model';

export const ROADS_SERVER_URL = '';
@Injectable({
  providedIn: 'root',
})
export class ShipmentsService {
  createItinerary(shipmentIds: string[]): Observable<Itinerary> {
    return this.client.post<Itinerary>(ROADS_SERVER_URL, shipmentIds);
  }
  getAllLegs(): Observable<Leg[]> {
    return this.client.get<Leg[]>(ROADS_SERVER_URL);
  }
  getAllCustomers(): Observable<CustomerInfo[]> {
    return this.client.get<CustomerInfo[]>(ROADS_SERVER_URL);
  }
  getAllItineraries(): Observable<Itinerary[]> {
    return this.client.get<Itinerary[]>(ROADS_SERVER_URL);
  }
  getAllLocations(): Observable<Location[]> {
    return this.client.get<Location[]>(ROADS_SERVER_URL);
  }
  getAllShipments(): Observable<Shipment[]> {
    return this.client.get<Shipment[]>(ROADS_SERVER_URL);
  }
  constructor(private client: HttpClient) {}
}
