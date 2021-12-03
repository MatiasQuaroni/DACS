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

@Injectable({
  providedIn: 'root',
})
export class ShipmentsService {
  createItinerary(shipmentIds: string[]): Observable<Itinerary> {
    return this.client.post<Itinerary>(this.baseApiUrl, shipmentIds);
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
}
