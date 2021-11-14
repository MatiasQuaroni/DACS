import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CustomerInfo, Itinerary, Shipment, Leg, Location } from '../+state/model';

export const ROADS_SERVER_URL = ''
@Injectable({
  providedIn: 'root',
})
export class ShipmentsService {
  createItinerary(shipmentIds: string[]): Observable<Itinerary> {
    this.client.post(ROADS_SERVER_URL, shipmentIds).subscribe((itinerary) =>{
      return itinerary
    }
  }
  getAllLegs(): Observable<Leg[]> {
    throw new Error('Method not implemented.');
  }
  getAllCustomers(): Observable<CustomerInfo[]> {
    throw new Error('Method not implemented.');
  }
  getAllItineraries(): Observable<Itinerary[]> {
    throw new Error('Method not implemented.');
  }
  getAllLocations(): Observable<Location[]> {
    throw new Error('Method not implemented.');
  }
  getAllShipments(): Observable<Shipment[]> {
    throw new Error('Method not implemented.');
  }
  constructor(private client: HttpClient) {}
}
